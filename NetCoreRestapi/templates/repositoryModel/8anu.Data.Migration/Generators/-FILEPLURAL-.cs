using System;
using System.Globalization;
using _8anu.Api.Common;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using System.Linq;
using _8anu.Data.Migration.Utilities;

namespace _8anu.Data.Migration.Generators
{
    public class [PLURAL] : IGenerator
    {
        public [PLURAL]()
        {
        }

        public string Generate(int maxRows, string staticFileName = "") {
            var items = new List<[SINGULAR]>();

            for (var i = 0; i < maxRows; i++) {
                var item = new [SINGULAR]
                {
                    Id = i,
                    Slug = "padi-is-a-gay-[L-SINGULAR]-number-" + i.ToString()
                };
                items.Add(item);    
            }
            var json = JsonConvert.SerializeObject(items);
            return json;
        }
    }
}