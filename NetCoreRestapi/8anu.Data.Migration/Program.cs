﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using _8anu.Data.Migration.Generators;
using System.Diagnostics;
using _8anu.Data.Migration.Utilities;
using Newtonsoft.Json;

namespace _8anu.Data.Migration
{


    class Program
    {
        private static int _overWriteMax = -1;
        private static bool _copyToOutputLocation = true;

        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            // Start!
            var timer = Stopwatch.StartNew();
            var runMain = true;
            foreach(var arg in args) 
            {
                if (arg == "test") 
                {
                    runMain = false;
                    var cleaner = new DbCleaner();
                    cleaner.showSomeTests();
                }
                else if (arg == "cleandb") 
                {
                    runMain = false;
                    var cleaner = new DbCleaner();
                    cleaner.CleanDb();
                }

                if (arg == "all")
                {
                    _overWriteMax = 4900000;
                    SeedStore.GenerateSQLFiles = true;
                }

                if (arg == "nocopy")
                {
                    _copyToOutputLocation = false;
                }

                if (arg == "temp")
                {
                    runMain = false;
                    var temp = new Temp();
                    temp.DoSomething();
                }
            }

            if (runMain)
            {
                MainRun();
            }

            timer.Stop();
            TimeSpan timespan = timer.Elapsed;
            Console.WriteLine("Completed! took " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));
        }

        static void MainRun()
        {
            // Create service collection
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Get backup sources for client

            // List<String> sources = configuration.GetSection("Backup:Sources").GetChildren().Select(x => x.Value).ToList();

            // var sqlConnectionString = configuration.GetConnectionString("AWSConnection");
            // Console.WriteLine("connectionstring: " + sqlConnectionString);

            // get and create folder for output if not exists
            var di = Directory.GetParent(AppContext.BaseDirectory);
            var root = di.FullName;
            var outputPath = root + Path.DirectorySeparatorChar + "output";
            var sqlOutputpath = root + Path.DirectorySeparatorChar + "sql";
            var inputPath = root + Path.DirectorySeparatorChar + "input";
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            if (!Directory.Exists(sqlOutputpath))
            {
                Directory.CreateDirectory(sqlOutputpath);
            }

            // get settings
            var msettings = configuration.GetSection("MigrationSettings");
            var maxRowsPerTable = msettings.GetValue<int>("MaxRowsPerTable");
            if (_overWriteMax > -1) 
            {
                maxRowsPerTable = _overWriteMax;    
            }
            SeedStore.MaxRowsPerTable = maxRowsPerTable;
            Console.WriteLine("max rows: " + maxRowsPerTable.ToString());

            // add constants to seedsettings
            var myConstants = new Dictionary<string, string>();
            var constants = msettings.GetSection("Constants");
            if (constants != null && constants.GetChildren().Any()) {
                foreach (var item in constants.GetChildren()) {
                    var key = item.GetValue<string>("name");
                    var value = item.GetValue<string>("value");
                    SeedStore.Settings.Add(key, value);
                }

            }


            // text to add to all files so dev's know these files will be overwritten
            var infoText = @"// 
// THIS FILE IS GENERATED BY
// 8anu.Data.Migration command line tool
// 
//" + Environment.NewLine;

            // get path where to copy the files
            var copyPath = di.Parent.Parent.Parent.Parent.FullName;
            copyPath = copyPath + Path.DirectorySeparatorChar + "8anu.Api" + Path.DirectorySeparatorChar + "Seed" + Path.DirectorySeparatorChar + "input";
            Console.WriteLine("path to copy files to = " + copyPath);

            // delete all files from the output folder
            Array.ForEach(Directory.GetFiles(outputPath), filePath => File.Delete(filePath));
            // delete all files from the destination folder
            if (_copyToOutputLocation)
            {
                Array.ForEach(Directory.GetFiles(copyPath), filePath => File.Delete(filePath));
            }

            // copy configuration file contents to output location
            var sourcePathAndFile = root + Path.DirectorySeparatorChar + "migrationsettings.json";
            var configContent = File.ReadAllText(sourcePathAndFile);
            configContent = infoText + configContent;
            var destinationPathAndFile = copyPath + Path.DirectorySeparatorChar + "migrationsettings.json";
            if (_copyToOutputLocation)
            {
                File.WriteAllText(destinationPathAndFile, configContent);
                Console.WriteLine("copied migrationsettings.json to destination");
            }

            var models = msettings.GetSection("Models").GetChildren();

            // hard coded to be able to save crags again after the loop
            var cragsFileName = "";
            IGenerator cragsGenerator = null;

            foreach (var model in models) {
                var maxRows = maxRowsPerTable;
                try {
                    maxRows = model.GetValue<int>("MaxRowsPerTable");
                }
                catch {}
                
                var name = model.GetValue<string>("Name");
                var cls = model.GetValue<string>("GeneratorClass");
                var inputFile = model.GetValue<string>("InputFile");
                Console.Write("generate (" + (maxRows > 0 ? maxRows.ToString() : "all") + ")items for: " + name + " (" + (cls.Length > 0 ? cls : ("static: " + inputFile)) + ") .... ");

                // get model properties
                if (model.GetValue<bool>("Skip", false)) 
                {
                    Console.Write("SKIP" + Environment.NewLine);
                    continue;
                }

                var streamOut = model.GetValue<bool>("StreamOut", false);


                // get type & generate content
                var json = "";
                var inputFileName = "";
                if (!string.IsNullOrEmpty(inputFile))
                {
                    inputFileName = inputPath + Path.DirectorySeparatorChar + inputFile;
                }

                // generator takes care of streaming the output
                if (streamOut) 
                {
                    inputFileName = outputPath + Path.DirectorySeparatorChar + name + ".json";
                }

                if (cls.Length > 0)
                {
                    var myType = Type.GetType(cls);
                    IGenerator generator = (IGenerator)Activator.CreateInstance(myType);
                    json = generator.Generate(maxRows, inputFileName);


                    if (SeedStore.GenerateSQLFiles)
                    {
                        var sqlFile = sqlOutputpath + Path.DirectorySeparatorChar + name + ".sql";
                        generator.GenerateSqlFile(sqlFile);


                    }

                    if (name == "crags")
                    {
                        cragsGenerator = generator; 
                    }
                }

                // write file and copy file
                var filename = name + ".json";
                var pathAndName = outputPath + Path.DirectorySeparatorChar + filename;

                if (!streamOut)
                {
                    json = infoText + json;
                    File.WriteAllText(pathAndName, json);
                }
                if (name == "crags") 
                {
                    cragsFileName = pathAndName;
                }
                
                // copy file to api project
                // don't copy files since we zip them later on and copy all at once
                // var copyPathAndName = copyPath + Path.DirectorySeparatorChar + filename;
                // File.Copy(pathAndName, copyPathAndName, true);

                Console.Write("done!" + Environment.NewLine);
            }

            // if crags have to be generated again...
            if (cragsFileName != "") 
            {
                var json = JsonConvert.SerializeObject(SeedStore.GetCrags());
                json = infoText + json;
                File.WriteAllText(cragsFileName, json);

                if (SeedStore.GenerateSQLFiles)
                {
                    var sqlFile = sqlOutputpath + Path.DirectorySeparatorChar + "crags" + ".sql";
                    cragsGenerator.GenerateSqlFile(sqlFile);
                }
            }

            // create all.sql
            var allSqlFile = sqlOutputpath + Path.DirectorySeparatorChar + "all.sql";
            File.WriteAllText(allSqlFile, SeedStore.AllSql);
            
            var sqlpath = root + Path.DirectorySeparatorChar + "sql";
            var sqlzipfile = "seed_data_sql.zip";
            sqlzipfile = root + Path.DirectorySeparatorChar + sqlzipfile;
            File.Delete(sqlzipfile);
            ZipFile.CreateFromDirectory(sqlpath, sqlzipfile);

            // zip seed data files and copy to api project
            var zipFileName = "seed_data_json.zip";
            var zipPathAndFileName = root + Path.DirectorySeparatorChar + zipFileName;
            File.Delete(zipPathAndFileName);
            ZipFile.CreateFromDirectory(outputPath, zipPathAndFileName);
            if (_copyToOutputLocation) 
            {
                var dest = copyPath + Path.DirectorySeparatorChar + zipFileName;
                File.Copy(zipPathAndFileName, dest, true);
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add logging
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            serviceCollection.AddLogging();

            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("migrationsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            // Add services
            // serviceCollection.AddTransient<IBackupService, BackupService>();

            // Add app
            // serviceCollection.AddTransient<App>();
        }
    }
}