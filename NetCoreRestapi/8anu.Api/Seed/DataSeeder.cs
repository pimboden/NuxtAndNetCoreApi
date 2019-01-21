using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace _8anu.Api.Seed
{
    public class DataSeeder
    {
        private void clearDatabaseTables(Data.Contexts.DomainModelMySqlContext context,
                                        IEnumerable<JToken> models)
        {
            Console.WriteLine("emptying whole DB...");
            
            var dbName = context.Database.GetDbConnection().Database;

            // this is for returning all tables from DB for deleting
            // but there doesn't seem to be a way to return string
            // from DB
            var sql = @"SELECT concat('DROP TABLE IF EXISTS `', table_name, '`;')
            FROM information_schema.tables
            WHERE table_schema = '" + dbName + "';";

            /*
            sql += " AND (";
            foreach(var model in models)
            {
                var s = string.Format(" OR table_name = '{0}'", (string)model["Name"]);
                sql += s;
            }
            sql += ");";
            */

            var conn = context.Database.GetDbConnection();

            try
            {
                conn.Open();

                var delScript = "SET FOREIGN_KEY_CHECKS = 0;" + Environment.NewLine;

                // get the delete script
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            delScript += rdr[0] + Environment.NewLine;
                        }
                        rdr.Close();
                    }

                    delScript += "SET FOREIGN_KEY_CHECKS = 1;";
                    cmd.CommandText = delScript;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            finally
            {
                conn.Close();
            }

        }

        string _inputDirectory;
        bool _globalOneAtTheTime = false;

        public void Seed(IServiceProvider serviceProvider)
        {
            var timer = Stopwatch.StartNew();
            Console.WriteLine("migrations & seeding:");

            // get settings
            _inputDirectory = "Seed" + Path.DirectorySeparatorChar + "input" + Path.DirectorySeparatorChar;
            var settings = JObject.Parse(File.ReadAllText(_inputDirectory + "migrationsettings.json"))["MigrationSettings"];
            var createAlways = (bool)settings["CreateAlways"];
            var neverSeed = (bool) settings["NeverSeed"];
            _globalOneAtTheTime = (bool)settings["ImportOneAtTheTime"];
            var models = settings["Models"].Children().Where(m => (bool)m["Skip"] == false);

            // get data context
            var context = serviceProvider.GetService<_8anu.Api.Data.Contexts.DomainModelMySqlContext>();
            // DbContextOptionsBuilder.EnableSensitiveDataLogging

            var newMigrationsExists = false;
            newMigrationsExists = context.Database.GetPendingMigrations().Any();

            // if we got new migrations or if data should be seeded every time we delete all the tables
            // that don't have 
            if (neverSeed == false && (createAlways || newMigrationsExists))
            {
                clearDatabaseTables(context, models);
                // after deleting tables, migrations definitely exists
                newMigrationsExists = true;
            }

            // migrate data
            if (newMigrationsExists)
            {
                // first we get script to "get the script" to delete all tables....
                Console.WriteLine("migrations exists, running migrations");
                context.Database.Migrate();
            }
            else
            {
                Console.WriteLine("no new migrations");
            }


            // seed database if it should run even when migrations are not executed
            // or if migrations are executed
            if (neverSeed == false && (createAlways || newMigrationsExists))
            {
                Console.WriteLine("seeding database");

                // let's unzip the data.zip here
                ZipFile.ExtractToDirectory(_inputDirectory + "seed_data_json.zip", _inputDirectory + "extracted-files", true);

                //
                // insert data
                //
                foreach (var model in models)
                {
                    importTypeWithReader(model, context);
                }
            }
            else
            {
                Console.WriteLine("not seeding database");
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            Console.WriteLine("Completed migration/seeding! took " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));
        }

        private void importTypeWithReader(JToken model, Data.Contexts.DomainModelMySqlContext context)
        {
            var typeName = (string)model["ModelTypeName"];
            var fileName = (string)model["Name"];
            fileName = _inputDirectory + "extracted-files" + Path.DirectorySeparatorChar + fileName + ".json";

            var oneAtTheTime = _globalOneAtTheTime;

            // check if we should import one at the time (this is used for debugging)
            if (model["ImportOneAtTheTime"] != null)
            {
                oneAtTheTime = (bool)model["ImportOneAtTheTime"];
            }

            Console.WriteLine("seeding data: " + typeName + " .... ");

            // get types
            var myType = Type.GetType(typeName);
            var myListType = typeof(List<>).MakeGenericType(myType);

            var logTimes = 0; // used for debugging

            context.ChangeTracker.AutoDetectChangesEnabled = false;
            var commitCount = 100000;

            var objItems = new HashSet<object>();
            using (var stream = File.OpenRead(fileName))
            using (StreamReader streamReader = new StreamReader(stream))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.SupportMultipleContent = true;

                var serializer = new JsonSerializer();
                while (reader.Read()) 
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        var myObject = serializer.Deserialize(reader, myType);
                        objItems.Add(myObject);

                        // save to every x-objects
                        if (objItems.Count() == commitCount)
                        {
                            Console.WriteLine("inserting " + (++logTimes * commitCount).ToString("#,##0"));
                            context.AddRange(objItems);
                            try 
                            {
                                context.SaveChanges();
                            }
                            catch (Exception ex) 
                            {
                                Console.Write(ex.ToString());
                            }
                            objItems = new HashSet<object>();
                        }
                    }
                }

                if (objItems.Any())
                {
                    Console.WriteLine("inserting: " + objItems.Count().ToString("#,##0"));
                    context.AddRange(objItems);
                    context.SaveChanges();
                }
            }    

            Console.Write("done!" + Environment.NewLine);
        }

        private void importType(JToken model, Data.Contexts.DomainModelMySqlContext context)
        {
            var typeName = (string)model["ModelTypeName"];
            var fileName = (string)model["Name"];
            fileName = _inputDirectory + "extracted-files" + Path.DirectorySeparatorChar + fileName + ".json";

            var oneAtTheTime = _globalOneAtTheTime;

            // check if we should import one at the time (this is used for debugging)
            if (model["ImportOneAtTheTime"] != null)
            {
                oneAtTheTime = (bool)model["ImportOneAtTheTime"];
            }

            Console.Write("seeding data: " + typeName + " .... ");

            // get types
            var myType = Type.GetType(typeName);
            var myListType = typeof(List<>).MakeGenericType(myType);
            var items = (IEnumerable<object>)JsonConvert.DeserializeObject(File.ReadAllText(fileName), myListType);
            var objItems = items.ToArray<object>();

            if (!oneAtTheTime)
            {
                context.AddRange(objItems);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            else
            {
                var count = objItems.Count();
                var ind = 0;
                Console.Write(" " + count.ToString() + " items ... ");

                // lets add one by one
                foreach (var item in objItems)
                {
                    ind++;
                    if (ind % 10 == 0)
                    {
                        Console.Write(".");
                    }

                    try
                    {
                        context.Add(item);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("EXCEPTION ADDING OBJECT:");
                        Console.WriteLine(item);
                        throw ex.InnerException;
                    }
                }
            }

            Console.Write("done!" + Environment.NewLine);
        }
    }
}
