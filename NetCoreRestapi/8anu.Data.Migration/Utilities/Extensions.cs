using System;
namespace _8anu.Data.Migration.Utilities
{
    public static class Extensions
    {
        public static string ToSqlInsertString(this string s, bool nullifempty = true)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (nullifempty)
                    return "NULL";
                else
                    return "''";
            }
            return string.Concat("'", s, "'");
        }

        public static string ToSqlInsertStringEscape(this string s, bool nullifempty = true)
        {
            if (string.IsNullOrEmpty(s)) 
            {
                if (nullifempty)
                    return "NULL";
                else
                    return "''";
            }
            return s.Replace(@"\", @"\\").Replace("'", @"\'").ToSqlInsertString();
        }

        public static string ToSqlInsertString(this DateTime d) 
        {
            return d.ToString("yyyy-MM-dd HH:mm:ss.f").ToSqlInsertString();    
        }
    }
}
