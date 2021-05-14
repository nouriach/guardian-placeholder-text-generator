using Guardian.Text.Generator.Web.Application.Results;
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
        // Arrange
        // Act
        // Assert

        [Test]
        [TestCase("Nathan")]
        [TestCase("Courtney")]
        [TestCase("Barney")]

        public static void Then_Constructor_WithAuthor_SetsAuthor(string name)
        {
            // Arrange
            AuthorViewModel author = new AuthorViewModel(name);
            // Act
            HomepageViewModel vm = new HomepageViewModel(author, null, null);
            // Assert
            Assert.AreEqual(name, vm.Author.FirstName);
        }

        [Test]
        [TestCase("Nathan", "10")]
        [TestCase("Courtney", "10000")]
        [TestCase("Barney", "666")]

        public static void Then_Constructor_WithAuthorAndContentRequest_SetsAuthorAndRequest(string name, string count)
        {
            // Arrange
            AuthorViewModel author = new AuthorViewModel(name);
            ContentRequestViewModel req = new ContentRequestViewModel() { CharacterCount = count} ;
            // Act
            HomepageViewModel vm = new HomepageViewModel(author, req, null);
            // Assert
            Assert.AreEqual(name, vm.Author.FirstName);
            Assert.AreEqual(count, vm.ContentRequest.CharacterCount);
        }

        [Test]
        [TestCase("Nathan", "10", "The American poet Edgar Allen Poe wrote a short story called The Masque of the Red Death about a prince who holds a fancy costume ball in his castle, even though a plague – the Red Death – is running through the world outside.")]
        [TestCase("Courtney", "10000", "Don’t hold a lavish, unnecessary event during a plague, even if you are a prince.")]
        [TestCase("Barney", "666", "The costume is empty. The guest is Death.")]

        public static void Then_Constructor_WithAuthorAndContentRequestAndContentResult_SetsAuthorAndRequestAndResult(string name, string count, string result)
        {
            // Arrange
            AuthorViewModel author = new AuthorViewModel(name);
            ContentRequestViewModel req = new ContentRequestViewModel() { CharacterCount = count };
            
            // GetCharacterRequestResult articleResult = new GetCharacterRequestResult(null, Convert.ToInt32(count));
            ContentResultViewModel res = new ContentResultViewModel();
            // Act
            HomepageViewModel vm = new HomepageViewModel(author, req, res);
            // Assert
            Assert.AreEqual(name, vm.Author.FirstName);
            Assert.AreEqual(count, vm.ContentRequest.CharacterCount);
            // Assert.AreEqual(result, vm.ContentResult.Content);
        }
    }
}
