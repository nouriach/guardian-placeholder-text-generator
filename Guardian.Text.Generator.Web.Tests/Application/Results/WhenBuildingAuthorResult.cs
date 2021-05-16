using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Application.Results
{
    public class WhenBuildingAuthorResult
    {
        [Test]
        public static void GivenConstructor_WithAuthorObject_ReturnsResult()
        {
            // Arrange
            Rootobject author = new Rootobject()
            {
                response = new Response
                {
                    results = new []
                    {
                        new Article
                        {
                            tags = new []
                            {
                                new Bio()
                                {
                                    webTitle = "Barney Ronay",
                                    webUrl = "https://www.theguardian.com/profile/barneyronay",
                                    bio = "<p>Barney Ronay is chief sports writer for the Guardian</p>",
                                    bylineImageUrl = "https://uploads.guim.co.uk/2018/05/25/Barney-Ronay.jpg",
                                    bylineLargeImageUrl = "https://uploads.guim.co.uk/2018/05/25/Barney-Ronay.jpg",
                                    firstName = "Barney",
                                    lastName = "Ronay"
                                },
                            }
                        }
                    }
                }
            };

            // Act
            GetAuthorResult actual = new GetAuthorResult(author);
            var expected = author.response.results[0].tags[0];

            // Assert
            Assert.AreEqual(expected.webTitle, actual.AuthorName);
            Assert.AreEqual(expected.webUrl, actual.Url);
            Assert.AreEqual("Barney Ronay is chief sports writer for the Guardian", actual.Bio);
            Assert.AreEqual(expected.bylineImageUrl, actual.AuthorImageSmall);
            Assert.AreEqual(expected.bylineLargeImageUrl, actual.AuthorImageLarge);
            Assert.AreEqual(expected.firstName, actual.FirstName);
            Assert.AreEqual(expected.lastName, actual.LastName);
        }
    }
}
