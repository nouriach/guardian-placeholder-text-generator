using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Models;
using Guardian.Text.Generator.Web.Models.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Models.ViewModels
{
    public class WhenInstantiatingAuthorViewModel
    {
        [Test]
        public void GivenConstructor_FillProperties_WithAuthorResult()
        {
            // Arrange
            Rootobject author = new Rootobject()
            {
                response = new Response
                {
                    results = new[]
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

            GetAuthorResult result = new GetAuthorResult(author);

            //Act
            AuthorViewModel vm = new AuthorViewModel(result);
            var expected = author.response.results[0].tags[0];

            //Assert
            Assert.AreEqual(result.FirstName, vm.FirstName);
            Assert.AreEqual(result.LastName, vm.LastName);
            Assert.AreEqual(result.Url, vm.Url);
            Assert.AreEqual(result.Bio, vm.Bio);
            Assert.AreEqual(result.AuthorImageSmall, vm.AuthorImageSmall);
            Assert.AreEqual(result.AuthorImageLarge, vm.AuthorImageLarge);


        }
    }
}
