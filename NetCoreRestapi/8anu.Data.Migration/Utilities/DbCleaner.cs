using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using _8anu.Data.Migration.Model;
           
namespace _8anu.Data.Migration.Utilities
{
    public class DbCleaner
    {
        public DbCleaner()
        {
        }

        public void showSomeTests() 
        {
            var input = new string[]
            {
                "Skar&#380;yce",
                "Bo&#345;e&#328;",
                "Ci&#281;&#380;kowice",
                "Zimny Dó&#322;",
                "10-, po bo&#380emu, bez nowych klamek",
                "hal&#kk",
                "hal&#;kk",
                "hal&#1kk",
                "hal&#1;kk",
                "hal&#11kk",
                "hal&#11;kk",
                "hal&#380kk",
                "hal&#380;kk",
                "hal&#",
                "hal&#;",
                "hal&#1",
                "hal&#1;",
                "hal&#11",
                "hal&#11;",
                "hal&#380",
                "hal&#380;",
            };

            foreach(var s in input) 
            {
                //var old = s;
                var news = unidecode(s, out bool changed);
                //Console.WriteLine(string.Format("{0} ---> {1}", old, news));
            }

            var str = "bo&#380";
            var ptrn = @"(&#\d{1,3})([^;]|$)";
            var output = Regex.Replace(str, ptrn, "$1;$2");
            var unicoded = System.Net.WebUtility.HtmlDecode(output);
            Console.WriteLine(string.Format("{0} ---> {1} ---> {2}", str, output, unicoded));
        }

        public void CleanDb()
        {
            cleanScores();
            cleanCrags();
            cleanSectors();
        }

        private string unidecode(string s, out bool changed) 
        {
            if (string.IsNullOrEmpty(s)) 
            {
                changed = false;
                return s;
            }

            var old = s;
            var newS = s.Trim();
            newS = System.Net.WebUtility.HtmlDecode(old);
            // trim again if we got spaces from htmldecode
            newS = newS.Trim();

            // add ';' to decoded characters without ';' character
            // for example &#380
            var ptrn = @"(&#\d{1,3})([^;]|$)";
            newS = Regex.Replace(newS, ptrn, "$1;$2");
            newS = System.Net.WebUtility.HtmlDecode(newS);
            // trim again if we got spaces from htmldecode
            newS = newS.Trim();

            // todo: remove characters &#12 (with 2 decimals)
            // todo: what about characters &# (with HEX)


            if (!old.Equals(newS))
            {
                changed = true;
                Console.WriteLine(string.Format("{0} ---> {1}", old, newS));
            }
            else
            {
                changed = false;
            }
            return newS;
        }

        private void cleanCrags() 
        {
            Console.WriteLine("*************************");
            Console.WriteLine("*** clean crags table ***");
            Console.WriteLine("*************************");
            var changedList = new List<Crag>();
            using (var context = new _8a_oldContext())
            {
                var firstZimny = false;
                foreach (Crag crag in context.Crag)
                {
                    var changed = false;
                    var firstRzed = false;
                    crag.Name = unidecode(crag.Name, out changed);
                    if (changed) 
                    {
                        if (crag.Name == "Ciężkowice"
                            
                            || crag.Name == "Kamień Leski"
                            || crag.Name == "Borzęta"
                            || crag.Name == "Skarżyce"
                            || crag.Name == "Čreta"
                            || crag.Name == "La Guairita"
                            || crag.Name == "Kusięta"
                            || crag.Name == "Żurowa"
                            || crag.Name == "Szklarska poręba"
                            || crag.Name == "Rożnów"
                            || crag.Name == "Wąwóz Ostryszni"
                            || crag.Name == "Céüse"
                            || crag.Name == "Rzêdkowice"
                            || crag.Name == "Wieżyca"
                            || crag.Name == "Smoleń"
                            || crag.Name == "Dolina Będkowska"
                            || crag.Name == "Csókakő"

                           )
                        {
                            crag.Name = crag.Name + " - copy";
                        }
                        else if (crag.Name == "Zimny Dół")
                        {
                            //crag.Name = crag.Name + " - 3";
                            var zimnyid = firstZimny ? 2 : 3;
                            crag.Name = crag.Name + " - " + zimnyid.ToString() + "copy";
                            firstZimny = true;
                        }
                        else if (crag.Name == "Rzędkowice")
                        {
                            //crag.Name = crag.Name + " - 3";
                            var id = firstRzed ? 2 : 3;
                            crag.Name = crag.Name + " - " + id.ToString() + "copy";
                            firstRzed = true;
                        }

                    }

                    crag.City = unidecode(crag.City, out changed);

                    if (changed)
                    {
                        changedList.Add(crag);
                    }
                }

                if (changedList.Any())
                {
                    context.Crag.UpdateRange(changedList);
                    context.SaveChanges();
                    Console.WriteLine("we saved now " + changedList.Count().ToString() + " crags...");
                }
            }
        }

        private void cleanSectors()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("*** clean sectors table ***");
            Console.WriteLine("***************************");
            var changedList = new List<CragSectors>();
            using (var context = new _8a_oldContext())
            {
                foreach (CragSectors sector in context.CragSectors)
                {
                    var changed = false;
                    sector.Name = unidecode(sector.Name, out changed);

                    if (changed)
                    {
                        changedList.Add(sector);
                    }
                }

                if (changedList.Any())
                {
                    context.CragSectors.UpdateRange(changedList);
                    context.SaveChanges();
                    Console.WriteLine("we saved now " + changedList.Count().ToString() + " sectors...");
                }
            }
        }

        private void cleanScores()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("*** clean score table ***");
            Console.WriteLine("*************************");

            var countries = new string[]
            {
                "Canada","Portugal","España","Italy","France","United Kingdom","Russia","Australia",
            "Spain","Brazil","United States","Slovenia","Ukraine","Switzerland","Malaysia",
            "Australia","Serbia [(]Yugoslavia[)]","South Africa","Germany","Mexico","Macedonia [(]Republic of[)]",
            "Greece","Austria","Croatia","Argentina","Poland","Laos","Turkey","India","Japan",
            "Bulgaria","China","Hungary","Thailand","Malta","United kingdom,","New Zealand",
            "Czech Republic","Philippines","Cuba","Colombia","Norway","Montenegro","Romania",
            "Macedonia","Sweden","Luxembourg"
            };

            var ptrn = string.Format(" ({0}) (Rout?e?s?|Bould?e?r?s?)( [(].*)?$", string.Join("|", countries));
            Regex countryBugRegex = new Regex(ptrn, RegexOptions.Compiled);

            var changedList = new List<Score>();
            using (var context = new _8a_oldContext())
            {
                foreach (Score score in context.Score)
                {
                    var changed = false;
                    score.Name = unidecode(score.Name, out changed);
                    score.Crag = unidecode(score.Crag, out changed);
                    score.CragSector = unidecode(score.CragSector, out changed);
                    score.Comment = unidecode(score.Comment, out changed);

                    var old = score.Crag;
                    score.Crag = countryBugRegex.Replace(score.Crag, "");
                    if (!old.Equals(score.Crag))
                    {
                        changed = true;
                        Console.WriteLine(old + " ---> " + score.Crag);
                    }

                    if (changed) 
                    {
                        changedList.Add(score);
                    }
                }

                if (changedList.Any())
                {
                    context.Score.UpdateRange(changedList);
                    context.SaveChanges();
                    Console.WriteLine("we saved now " + changedList.Count().ToString() + " scores...");
                }
            }

            /*
            using (var context = new _8a_oldContext())
            {
                var scores = context.Score.Where(s => reg.IsMatch(s.Crag)).ToList();

                foreach (var score in scores)
                {
                    var old = score.Crag;
                    score.Crag = reg.Replace(score.Crag, "");
                    Console.WriteLine(old + " ---> " + score.Crag);
                }
                context.Score.UpdateRange(scores);
                context.SaveChanges();
                Console.WriteLine(scores.Count().ToString() + " scores done");
            }
            */
        }
    }
}
