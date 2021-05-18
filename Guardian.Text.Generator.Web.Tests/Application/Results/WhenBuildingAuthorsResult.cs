using Guardian.Text.Generator.Web.Application.Results.Authors;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Application.Results
{
    public class WhenBuildingAuthorsResult
    {
        [Test]
        public static void GivenConstructor_WithAuthorsObject_ReturnsResult()
        {
            // Arrange
            List<string> list = new List<string>()
            {
                "xxx",
                "yyy",
                "zzz"
            };
            // Act
            GetAuthorsResult actual = new GetAuthorsResult(list);

            // Assert
            Assert.AreEqual(list, actual.Authors);
        }
    }
}
