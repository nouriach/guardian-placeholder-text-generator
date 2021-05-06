using Guardian.Text.Generator.Web.Infrastructure.Api;
using Guardian.Text.Generator.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
