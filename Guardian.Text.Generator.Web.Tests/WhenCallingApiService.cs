using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Guardian.Placeholder.Text.Generator.Web.Controllers;

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
            // Act
            // Assert
        }

        [Test]
        public static void And_Storing_Results_In_Model_Collection()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public static void And_Selecting_Random_Entry_From_Model_Collection()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
