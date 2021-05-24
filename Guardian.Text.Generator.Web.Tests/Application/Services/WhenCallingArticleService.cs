using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries;
using Guardian.Text.Generator.Web.Application.Queries.Articles;
using Guardian.Text.Generator.Web.Infrastructure.Api;
using Guardian.Text.Generator.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Tests.Application.Services
{
    public class WhenCallingArticleService
    {
        // Arrange
        // Act
        // Assert

        [Test]
        public static void GivenQuery_ThenCallsApiService_AndReturnsObject()
        {
            // Arrange
            Mock<IArticleService> mockService = new Mock<IArticleService>();

            // we are using the Verifiable to ensure that it runs
            mockService.Setup(m => m.GetArticlesAsync(It.IsAny<GetAllArticlesQuery>())).Verifiable();

            // I guess this sets up how the Mock should act
            mockService.Setup(m => m.GetArticlesAsync(It.IsAny<GetAllArticlesQuery>())).Returns(It.IsAny<Task<Article>>());

            var expected = It.IsAny<Task<Rootobject>>();
           
            // Act
            var result = mockService.Object.GetArticlesAsync(It.IsAny<GetAllArticlesQuery>());

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
