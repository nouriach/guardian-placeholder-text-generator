using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Guardian.Text.Generator.Web.Helpers
{
    public class SortCollectionIntoAlphabeticalOrder : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            return x.CompareTo(y);
        }
    }
}
