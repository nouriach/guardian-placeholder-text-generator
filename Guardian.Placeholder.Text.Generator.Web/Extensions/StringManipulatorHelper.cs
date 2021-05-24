using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Extensions
{
    public static class StringManipulatorHelper
    {
        public static string ToLowerAndTrim(this String str)
        {
            var copy = str.ToLower().Trim();
            return copy;
        }
    }
}
