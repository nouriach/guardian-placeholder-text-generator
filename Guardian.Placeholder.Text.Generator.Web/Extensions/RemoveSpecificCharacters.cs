
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
    }
}
