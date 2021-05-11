using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Extensions
{
    public static class RegexHelper
    {
        private static string _htmlRegex = "[<][^<>]*[>]";

        public static bool CheckIfCopyContainsHtml(this String str)
        {
            if (Regex.IsMatch(str, _htmlRegex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string RemoveHtmlFromString(this String str)
        {
            string cleanedCopy = Regex.Replace(str, _htmlRegex, "").Trim();
            return cleanedCopy;
        }
    }
}
