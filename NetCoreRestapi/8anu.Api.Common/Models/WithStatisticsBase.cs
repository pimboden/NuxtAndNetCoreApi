using System;
using System.Collections.Generic;
using System.Linq;
using Nest;
using Newtonsoft.Json;

namespace _8anu.Api.Common.Models
{
    public abstract class WithStatisticsBase 
    {
        protected WithStatisticsBase()
        {
            Children = new List<WithStatisticsBase>();
            
            int[] season = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Season = season;

            Grades = new Dictionary<int, int>();
        }

        [Ignore, JsonIgnore] // not sending parentId to client
        public WithStatisticsBase Parent { get; set; }
        
        [JsonIgnore] // not sending parentId to client
        public int? ParentId => Parent?.DatabaseId;
        
        // todo: dont send DatabaseId to client (do this when we have slug for zlaggables and for sectors
        // [JsonIgnore] // not sending parentId to client
        
        // change ide property name in elastic index because we have routes and boulders with same IDs 
        // and in elastic search id property is then used to update existing if 
        // objects with same id are inserted
        [Number(Name = "db_id")]
        public int DatabaseId { get; set; } // Id is called DatabaseId so elasticserach bulk insert lets duplicates in (in case of zlaggables)
        public string Name { get; set; }
        
        [Keyword]
        public string Slug { get; set; }
        
        [JsonIgnore] // ignore so we don't get problems with serializing
        public List<WithStatisticsBase> Children { get; set; }

        [JsonIgnore]
        public int TotalChildren { get; private set; }
        
        public int TotalZlaggables { get; set; }
        public int TotalAscents { get; set; }
        public int TotalAscents1Year { get; set; }
        
        public int TotalAscentsFlash { get; set; }
        public int TotalAscentsOnsight { get; set; }
        public int TotalAscentsRedPoint { get; set; }
        public int TotalAscentsGo { get; set; }
        public int TotalAscentsTopRope { get; set; }
        
        public int TotalRecommended { get; set; }
        public float? AverageRating { get; set; }

        public int[] Season { get; set; }

        public Dictionary<int, int> Grades { get; set; }

        [JsonProperty] // this is for json serializer too be able to set the protected property
        public float AscentRate1Year { get; protected set; }
        [JsonProperty] // this is for json serializer too be able to set the protected property
        public float TotalRecommendedRate { get; protected set; }
        [JsonProperty] // this is for json serializer too be able to set the protected property
        public float FlashRate { get; protected set; }
        [JsonProperty] // this is for json serializer too be able to set the protected property
        public float OnsightRate { get; protected set; }
        [JsonProperty] // this is for json serializer too be able to set the protected property
        public float FlashOnsightRate { get; protected set; }
        [JsonProperty] // this is for json serializer too be able to set the protected property
        public float RedPointRate { get; protected set; }
        [JsonProperty] // this is for json serializer too be able to set the protected property
        public float GoRate { get; protected set; }
        [JsonProperty] // this is for json serializer too be able to set the protected property
        public float TopRopeRate { get; protected set; }

        public void CalculateTotals()
        {
            if (this.Slug == "test-slug-25")
            {
                string s = "";
            }
            
            if (Children.Count > 0)
            {
                TotalAscents = Children.Sum(c => c.TotalAscents);
                TotalAscents1Year = Children.Sum(c => c.TotalAscents1Year);
                TotalZlaggables = Children.Sum(c => c.TotalZlaggables);
                TotalAscentsFlash = Children.Sum(c => c.TotalAscentsFlash);
                TotalAscentsOnsight = Children.Sum(c => c.TotalAscentsOnsight);
                TotalAscentsRedPoint = Children.Sum(c => c.TotalAscentsRedPoint);
                TotalAscentsGo = Children.Sum(c => c.TotalAscentsGo);
                TotalAscentsTopRope = Children.Sum(c => c.TotalAscentsTopRope);
                TotalRecommended = Children.Sum(c => c.TotalRecommended);
                AverageRating = Children.Average(c => c.AverageRating);
                TotalChildren = Children.Count;

                
                // sum all seasons and grades together
                foreach (var child in Children)
                {
                    for (var i = 0; i < 12; i++)
                    {
                        Season[i] += child.Season[i];
                    }

                    foreach (var key in child.Grades.Keys)
                    {
                        if (Grades.ContainsKey(key))
                        {
                            Grades[key] += child.Grades[key];
                        }
                        else
                        {
                            Grades.Add(key, child.Grades[key]);
                        }
                    }
                }
            }

            if (TotalAscents <= 0) return;
            
            var totalAscentsDouble = (float) TotalAscents;
            
            AscentRate1Year = TotalAscents1Year / totalAscentsDouble;
            TotalRecommendedRate = TotalRecommended / totalAscentsDouble;
            FlashRate = TotalAscentsFlash / totalAscentsDouble;
            OnsightRate = TotalAscentsOnsight / totalAscentsDouble;
            FlashOnsightRate = (TotalAscentsFlash + TotalAscentsOnsight) / totalAscentsDouble;
            RedPointRate = TotalAscentsRedPoint / totalAscentsDouble;
            GoRate = TotalAscentsGo / totalAscentsDouble;
            TopRopeRate = TotalAscentsTopRope / totalAscentsDouble;
        }
    }
}