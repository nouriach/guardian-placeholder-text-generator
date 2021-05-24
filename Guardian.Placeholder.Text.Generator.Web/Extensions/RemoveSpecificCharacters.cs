
using System;

namespace Guardian.Text.Generator.Web.Extensions
{
    public static class RemoveSpecificCharacters
    {
        public static string RemoveNonBreakingSpaceFromString(this String str)
        {
            string cleanedCopy = str.Replace("&nbsp;", " ");
            return cleanedCopy;
        }

        public static string RemoveCssFromString(this String str)
        {
            if (str.Contains("css"))
            {
                var firstIndex = str.IndexOf(".");
                var lastIndex = str.LastIndexOf("}");
                string cleanedCopy = str.Remove(firstIndex, lastIndex);
                return cleanedCopy;
            }
            return str;
        }
    }
}
