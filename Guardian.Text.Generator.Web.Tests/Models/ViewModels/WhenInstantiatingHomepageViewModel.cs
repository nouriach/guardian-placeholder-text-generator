﻿using Guardian.Text.Generator.Web.Application.Results;
using Guardian.Text.Generator.Web.Application.Results.Articles;
using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Models;
using Guardian.Text.Generator.Web.Models.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardian.Text.Generator.Web.Tests.Models
{
    public class WhenInstantiatingHomepageViewModel
    {
        private static AuthorViewModel BuildAuthorViewModel()
        {
            var author = new Article()
            {
                tags = new[]
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
            };

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

            return new AuthorViewModel(result);
        }
        // Arrange
        // Act
        // Assert

        [Test]
        public static void Then_Constructor_WithAuthor_SetsAuthor()
        {
            // Arrange

            var authorVM = BuildAuthorViewModel();
            // Act
            HomepageViewModel vm = new HomepageViewModel(authorVM, null, null);
            // Assert
            Assert.AreEqual("Barney", vm.Author.FirstName);
        }


        [Test]
        [TestCase("Nathan", "10")]
        [TestCase("Courtney", "10000")]
        [TestCase("Barney", "666")]

        public static void Then_Constructor_WithAuthorAndContentRequest_SetsAuthorAndRequest(string name, string count)
        {
            // Arrange
            var authorVM = BuildAuthorViewModel();
            GetAuthorsResult authors = new GetAuthorsResult()
            {
                Authors = new List<string>()
                {
                    "www",
                    "xxx",
                    "yyy",
                    "zzz"
                }
            };
            ContentRequestViewModel req = new ContentRequestViewModel(authors) { CharacterCount = count} ;
            // Act
            HomepageViewModel vm = new HomepageViewModel(authorVM, req, null);
            // Assert
            Assert.AreEqual("Barney", vm.Author.FirstName);
            Assert.AreEqual(count, vm.ContentRequest.CharacterCount);
        }

        [Test]
        [TestCase("Nathan", "10", "The American poet Edgar Allen Poe wrote a short story called The Masque of the Red Death about a prince who holds a fancy costume ball in his castle, even though a plague – the Red Death – is running through the world outside.")]
        [TestCase("Courtney", "10000", "Don’t hold a lavish, unnecessary event during a plague, even if you are a prince.")]
        [TestCase("Barney", "666", "The costume is empty. The guest is Death.")]

        public static void Then_Constructor_WithAuthorAndContentRequestAndContentResult_SetsAuthorAndRequestAndResult(string name, string count, string result)
        {
            // Arrange
            var authorVM = BuildAuthorViewModel();
            GetAuthorsResult authors = new GetAuthorsResult()
            {
                Authors = new List<string>()
                {
                    "www",
                    "xxx",
                    "yyy",
                    "zzz"
                }
            };
            ContentRequestViewModel req = new ContentRequestViewModel(authors) { CharacterCount = count };
            
            // GetCharacterRequestResult articleResult = new GetCharacterRequestResult(null, Convert.ToInt32(count));
            ContentResultViewModel res = new ContentResultViewModel();
            // Act
            HomepageViewModel vm = new HomepageViewModel(authorVM, req, res);
            // Assert
            Assert.AreEqual("Barney", vm.Author.FirstName);
            Assert.AreEqual(count, vm.ContentRequest.CharacterCount);
        }
    }
}
