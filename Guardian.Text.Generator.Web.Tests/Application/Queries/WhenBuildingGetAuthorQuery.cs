using Guardian.Text.Generator.Web.Application.Queries.Authors;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Application.Queries
{
    public class WhenBuildingGetAuthorQuery
    {
        // Arrange
        // Act
        // Assert

        [Test]
        [TestCase("Barney Ronay")]
        [TestCase("Nick Ames")]
        [TestCase("Scott Murray")]
        [TestCase("Jacob Steinberg")]
        [TestCase("David Hytner")]
        [TestCase("John Ashdown")]
        [TestCase("Jonathan Wilson")]
        public void And_Query_Receives_Request_Then_Sets_Name(string req)
        {
            // Arrange
            GetAuthorQuery query = new GetAuthorQuery()
            {
                Name = req
            };

            // Act
            // Assert
            Assert.AreEqual(req, query.Name);
        }
    }
}
