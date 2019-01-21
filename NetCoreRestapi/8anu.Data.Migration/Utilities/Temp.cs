using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _8anu.Data.Migration.Model;

namespace _8anu.Data.Migration.Utilities
{
    public class Temp
    {
    
        
        public void DoSomething() 
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("*** analyze wrongly inserted ascents ***");
            Console.WriteLine("****************************************");
            
            var wrongList = new List<Score>();
            using (var context = new _8a_oldContext())
            {
                // first we take all crags and scores to a hashtable
                var crags = context.Crag.ToDictionary(k => k.Name + "_" + k.CountryId + "_" + k.Type.ToString(), v => v);
                // var sectors = context.CragSectors.ToDictionary(k => k.Id, v => v);

                var totalNotFoundWithRightType = 0;
                var totalFoundWithOtherKey = 0;
                var totalNotFoundAtAll = 0;
                foreach (Score score in context.Score)
                {
                    var cragKey = score.Crag + "_" + score.Country + "_" + score.What.ToString();
                    
                    // find our crag
                    if (!crags.ContainsKey(cragKey))
                    {
                        Console.WriteLine("no crag found with matching ascent type:" + cragKey);
                        totalNotFoundWithRightType++;
                        
                        cragKey = score.Crag  + "_" + score.Country + "_" + (score.What == 0 ? 1 : 0).ToString();
                        
                        if (!crags.ContainsKey(cragKey))
                        {
                            Console.WriteLine("no crag found with OPPOSITE ascent type: " + cragKey);
                            totalNotFoundAtAll++;
                        }
                        else
                        {
                            totalFoundWithOtherKey++;
                        }
                    }
                    
                    // if found let's get the crag
                    // var crag = crags.ContainsKey(cragKey);
                }
                
                Console.WriteLine("not found with right type: " + totalNotFoundWithRightType);
                Console.WriteLine("FOUND with WRONG type: " + totalFoundWithOtherKey);
                Console.WriteLine("not found at all: " + totalNotFoundAtAll);
            }
        }
    }
    
}