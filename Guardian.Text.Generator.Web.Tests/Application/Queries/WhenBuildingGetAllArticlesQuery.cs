using Guardian.Text.Generator.Web.Application.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Application.Queries
{
    public class WhenBuildingGetAllArticlesQuery
    {
        // Arrange
        // Act
        // Assert

        [Test]
        [TestCase("350")]
        [TestCase("250")]
        [TestCase("100")]
        [TestCase("300")]
        [TestCase("150")]
        [TestCase("200")]
        public void QueryPassedRequest_ThenCharacterCountIsSet(string req)
        {
            // Arrange
            // Act
            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                RequestCount = req
            };
            // Assert
            Assert.AreEqual(req, query.RequestCount);
        }
    }
}
