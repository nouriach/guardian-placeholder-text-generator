using Guardian.Text.Generator.Web.Infrastructure.Api;
using Guardian.Text.Generator.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Tests.Infrastructure.Api
{
    public class WhenCallingApiService
    {
        //Arrange
        //Act
        //Assert
        [Test]
        public static void And_Result_Contains_Ten_Articles()
        {
            //Arrange
            //Act
            var result = ApiService.SendRequestAndGetArticles();
            var actual = result.Result.response.results.Length;
            var expected = 10;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void And_Result_Returns_Correct_Dto()
        {
            //Arrange
            //Act
            var result = ApiService.SendRequestAndGetArticles();
            //Assert
            Assert.IsInstanceOf<Rootobject>(result.Result);
        }

        [Test]
        [TestCase("Barney Ronay")]
        [TestCase("Nick Ames")]
        [TestCase("Scott Murray")]
        [TestCase("Jacob Steinberg")]
        [TestCase("David Hytner")]
        [TestCase("John Ashdown")]
        [TestCase("Jonathan Wilson")]
        public async Task And_Author_Request_Returns_Author(string author)
        {
            //Arrange
            //Act
            var result = await ApiService.SendRequestAndGetAuthorBio(author);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("Barney Ronay", "q=barney-ronay")]
        [TestCase("Nick Ames", "q=nick-ames")]
        [TestCase("Scott Murray", "q=scott-murray")]
        [TestCase("Jacob Steinberg", "q=jacob-steinberg")]
        [TestCase("David Hytner", "q=david-hytner")]
        [TestCase("John Ashdown", "q=john-ashdown")]
        [TestCase("Jonathan Wilson", "q=jonathan-wilson")]
        public async Task And_Author_Request_Sets_AuthorQuery(string author, string expected)
        {
            //Arrange
            //Act
            var result = await ApiService.SendRequestAndGetAuthorBio(author);
            //Assert
            Assert.AreEqual(expected, ApiService._query);
        }
    }
}
