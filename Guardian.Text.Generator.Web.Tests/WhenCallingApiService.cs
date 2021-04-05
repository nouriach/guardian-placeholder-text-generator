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
            var url = HomeController.BuildApiCall();
            // Act
            var actual = HomeController.SendGuardianRequest(url);
            // Assert
            Assert.IsNotNull(actual.Result);
        }

        [Test]
        public static void And_Storing_Results_In_Model_CollectionAsync()
        {
            // Arrange
            HomeController.GetRandomPageNumber();
            var url = HomeController.BuildApiCall();
            // Act
            var actual = HomeController.SendGuardianRequest(url);
            HomeController.MapJsonToArticleModel(actual.Result);
            // Assert
            Assert.IsNotNull(HomeController._articles);
            Assert.AreEqual("football", HomeController._articles.response.results[0].sectionName.ToLower());
            Assert.AreEqual(10, HomeController._articles.response.results.Length);
        }

        [Test]
        public static void And_Selecting_Random_Entry_From_Model_Collection()
        {
            // Arrange
            HomeController.GetRandomPageNumber();
            var url = HomeController.BuildApiCall();
            // Act
            var actual = HomeController.SendGuardianRequest(url);
            HomeController.MapJsonToArticleModel(actual.Result);
            HomeController.SelectRandomSingleArticleFromCollection();
            // Assert
            Assert.IsNotNull(HomeController._article);
        }

        [Test]
        [TestCase(15)]
        [TestCase(5)]
        [TestCase(600)]
        [TestCase(82)]

        public static void And_Setting_Character_Count_Request(int expected)
        {
            // arrange
            // act
            HomeController.SetCharacterCountRequest(expected);
            var actual = HomeController._characterCountRequest;
            // assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
