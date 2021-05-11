using Guardian.Text.Generator.Web.Application.Results;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Application.Results
{
    public class WhenBuildingArticleResult
    {

        private static readonly List<string> _sourceLists = new List<string>()
        {
            "a", "b", "c", "d", "z", "z",
        };


        [TestCase("abcde", "a", "b", "c", "d", "e")]
        [TestCase("aaaaaaaa", "aa", "a", "aaa", "a", "a")]
        [TestCase("This is an example sentence", "This ", "is ", "an ",  "example ", "sentence")]

        public static void GivenConstructor_WithStringCollectionAndCharcterCount_ReturnsContentString(string expected, params string[] collection)
        {
            // Arrange
            GetArticleResult result = new GetArticleResult(collection.ToList(), 50);
            // Act

            // Assert
            Assert.AreEqual(expected, result.Content);
        }
    }
}
