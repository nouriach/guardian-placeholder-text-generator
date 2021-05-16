using Guardian.Text.Generator.Web.Application.Results;
using Guardian.Text.Generator.Web.Application.Results.Articles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Application.Results
{
    public class WhenBuildingWordRequestResult
    {
        [TestCase("Test test test test. aaa", 5)]
        [TestCase("Test test test test. aaa bbb, ccc ddd ee ffff gg hhhhh! i jj kkkk llllll m n. oooo pppp", 20)]
        [TestCase("Test test test test. aaa bbb, ccc ddd ee ffff gg hhhhh! i jj kkkk llllll m n. oooo pppp qq rr ssssss tttttt; u", 25)]
        [TestCase("Test test test test. aaa bbb, ccc ddd ee ffff gg hhhhh! i jj kkkk llllll m n. oooo pppp qq rr ssssss tttttt; u v w xxxxxx yyyyyyy zz.", 30)]

        public static void GivenConstructor_WithStringCollectionAndCharacterCount_ReturnsContentString(string expected, int count)
        {
            // Arrange
            GetWordRequestResult result = new GetWordRequestResult(GetCopy(), count);
            // Act

            // Assert
            Assert.AreEqual(expected, result.Content);
        }

        private static List<string> GetCopy()
        {
            List<string> copy = new List<string>()
            {
                "Test test test test.",
                "aaa bbb, ccc ddd",
                "ee ffff gg hhhhh! i",
                "jj kkkk llllll m n. oooo",
                "pppp qq rr ssssss tttttt; u v",
                "w xxxxxx yyyyyyy zz."
            };

            return copy;
        }
    }
}
