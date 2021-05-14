using Guardian.Text.Generator.Web.Application.Results;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Application.Results
{
    public class WhenBuildingCharacterRequestResult
    {

        [TestCase("abcde", "a", "b", "c", "d", "e")]
        [TestCase("aaaaaaaa", "aa", "a", "aaa", "a", "a")]
        [TestCase("This is an example sentence", "This ", "is ", "an ",  "example ", "sentence")]

        public static void GivenConstructor_WithStringCollectionAndCharacterCount_ReturnsContentString(string expected, params string[] collection)
        {
            // Arrange
            GetCharacterRequestResult result = new GetCharacterRequestResult(collection.ToList(), 50);
            // Act

            // Assert
            Assert.AreEqual(expected, result.Content);
        }
    }
}
