using Guardian.Text.Generator.Web.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Extensions
{
    public class WhenUsingStringManipulatorHelper
    {
        [Test]
        [TestCase("    XXX xxx  ","xxx xxx")]
        [TestCase("    Yyyy Yyyy", "yyyy yyyy")]
        [TestCase("Zzzz Zzzz   ", "zzzz zzzz")]

        public static void GivenString_WithSpaces_ReturnToLowerAndTrim(string content, string expected)
        {
            var actual = content.ToLowerAndTrim();
            Assert.AreEqual(expected, actual);
        }
    }
}
