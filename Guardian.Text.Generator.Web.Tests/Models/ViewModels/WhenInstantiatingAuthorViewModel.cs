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
            Author result = new Author()
            {
                FirstName = "Barney",
                LastName = "Ronay",
                FullName = "Barney Ronay",
                Bio = "<p>Barney Ronay is chief sports writer for the Guardian</p>",
                BylineImageUrl = "https://uploads.guim.co.uk/2018/05/25/Barney-Ronay.jpg",
                BylineLargeImageUrl = "https://uploads.guim.co.uk/2018/05/25/Barney-Ronay.jpg",
                Url = "https://www.theguardian.com/profile/barneyronay",
            };

            //Act
            AuthorViewModel vm = new AuthorViewModel(result);
            var expected = result;

            //Assert
            Assert.AreEqual(result.FirstName, vm.FirstName);
            Assert.AreEqual(result.LastName, vm.LastName);
            Assert.AreEqual(result.Url, vm.Url);
            Assert.AreEqual(result.Bio, vm.Bio);
            Assert.AreEqual(result.BylineImageUrl, vm.AuthorImageSmall);
            Assert.AreEqual(result.BylineLargeImageUrl, vm.AuthorImageLarge);


        }
    }
}
