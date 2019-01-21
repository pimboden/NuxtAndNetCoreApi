using System.Collections.Generic;
using System.Web;
using System.Text.RegularExpressions;
using UnidecodeSharpFork;

namespace _8anu.Api.Common.Utilities
{
    public static class SlugGenerator
    {
        
        private static readonly Dictionary<string, string> MultiCharSpecialCharacters = new Dictionary<string, string>()
        {
            { "&&", "and" },
            { "||", "or" },
            { "w/", "with" }
        };

        private static readonly Dictionary<string, string> SpecialCharacters = new Dictionary<string, string>()
        {
            { "&", "and" },
            { "|", "or" },
            { "%", "percent" },
            { "☣", "biohazard" },
            { "¼", "" },
            { "±", "+" },
            { "°", "degree" },
            { "ö", "oe" },
            { "ä", "ae" },
            { "ü", "ue" },

            // currencies
            { "€", "euro" },
            { "₢", "cruzeiro" },
            { "₣", "french franc" },
            { "£", "pound" },
            { "₤", "lira" },
            { "₥", "mill" },
            { "₦", "naira" },
            { "₧", "peseta" },
            { "₨", "rupee" },
            { "₩", "won" },
            { "₪", "new shequel" },
            { "₫", "dong" },
            { "₭", "kip" },
            { "₮", "tugrik" },
            { "₯", "drachma" },
            { "₰", "penny" },
            { "₱", "peso" },
            { "₲", "guarani" },
            { "₳", "austral" },
            { "₴", "hryvnia" },
            { "₵", "cedi" },
            { "¢", "cent" },
            { "¥", "yen" },
            { "元", "yuan" },
            { "円", "yen" },
            { "﷼", "rial" },
            { "₠", "ecu" },
            { "¤", "currency" },
            { "฿", "baht" },
            { "$", "dollar" },
            { "₹", "indian rupee" }
        };
        
        public static string ToSlug(this string incomingString, string slugSeparator = "-", string postString = "")
        {
            incomingString = incomingString.Trim();
            incomingString = HttpUtility.HtmlDecode(incomingString.Trim());
            incomingString = incomingString.ToLower();
            incomingString = incomingString.RemoveHtmlTags();
            incomingString = incomingString.ReplaceSpecialCharacters();
            incomingString = incomingString.Trim().Unidecode();

            var alphaNum = Regex.Replace(incomingString, @"(^ )|[']|([^a-zA-Z0-9\s-.,/+_~])", string.Empty);
            // convert allowed characters to separator
            alphaNum = Regex.Replace(alphaNum, @"[,/._~]", slugSeparator);
            // convert spaces to separator
            alphaNum = Regex.Replace(alphaNum, @"\s+", slugSeparator);
            // convert more than 1 separator to separator
            alphaNum = Regex.Replace(alphaNum, @"-{2,}", slugSeparator);
            // remove leading/trailing separators
            alphaNum = Regex.Replace(alphaNum, "(^" + slugSeparator + ")|(" + slugSeparator + "$)", "");

            var retval = alphaNum;
            
            if (string.IsNullOrWhiteSpace(postString)) return retval.ToLower();
            
            postString = postString.ToSlug();
            retval += slugSeparator + postString;
            return retval.ToLower();
        }
        
        private static string RemoveHtmlTags(this string incomingString)
        {
            var retval = incomingString;

            retval = Regex.Replace(retval, @"(<.*?>)|([<>])", string.Empty);

            return retval;
        }
        
        private static string ReplaceSpecialCharacters(this string incomingString)
        {
            var retval = incomingString;

            retval = ReplaceCharacters(retval, MultiCharSpecialCharacters);
            retval = ReplaceCharacters(retval, SpecialCharacters);

            return retval;
        }
        
        private static string ReplaceCharacters(string source, Dictionary<string, string> charmap)
        {
            var retval = source;

            foreach (var key in charmap.Keys)
            {
                if (retval.Contains(key))
                {
                    retval = retval.Replace(key, charmap[key]);
                }
            }

            return retval;
        }
    }
}