using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Guardian.Placeholder.Text.Generator.Web.Controllers;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Tests
{
    public class WhenCallingApiService
    {
        [Test]
        public static void And_Selecting_Random_Page_Number()
        {
            // Arrange
            HomeController.GetRandomPageNumber();
            // Act
            // Assert
            Assert.IsFalse(HomeController._page == 0);
        }

        [Test]
        public static void And_Sending_Request_With_Random_Page_Number()
        {
            // Arrange
            HomeController.GetRandomPageNumber();
            // Act
            var actual = HomeController.SendGuardianRequest("https://content.guardianapis.com/search?pages=1&tag=football/football");
            // Assert
            Assert.IsNotNull(actual.Result);
        }

        [Test]
        public static async Task And_Storing_Results_In_Model_CollectionAsync()
        {
            // Arrange
            HomeController.GetRandomPageNumber();
            // Act
            var actual = await HomeController.SendGuardianRequest("https://content.guardianapis.com/search?pages=1&tag=football/football");
            HomeController.MapJsonToArticleModel(actual);
            // Assert
            Assert.IsNotNull(HomeController._articles);
            Assert.AreEqual("football", HomeController._articles.response.results[0].sectionName.ToLower());
            Assert.AreEqual(10, HomeController._articles.response.results.Length);
        }

        [Test]
        public static async Task And_Selecting_Random_Entry_From_Model_Collection()
        {
            // Arrange
            HomeController.GetRandomPageNumber();
            // Act
            var actual = await HomeController.SendGuardianRequest("https://content.guardianapis.com/search?pages=1&tag=football/football");
            HomeController.MapJsonToArticleModel(actual);
            HomeController.SelectRandomSingleArticleFromCollection();
            // Assert
            Assert.IsNotNull(HomeController._article);
        }
    }
}
