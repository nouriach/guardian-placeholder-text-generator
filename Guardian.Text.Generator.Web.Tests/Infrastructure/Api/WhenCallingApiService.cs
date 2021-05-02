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
            var actual = ApiService.SendRequestAndGetArticles();
            //Assert
            Assert.AreEqual(actual.Result.response.results.Length, 10);
        }
    }
}
