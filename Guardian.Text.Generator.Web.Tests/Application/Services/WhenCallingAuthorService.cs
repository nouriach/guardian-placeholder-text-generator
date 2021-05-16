using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Tests.Application.Services
{
    class WhenCallingAuthorService
    {
        [Test]
        public static void GivenQuery_ThenCallsApiService_AndReturnsObject()
        {
            // Arrange
            Mock<IAuthorService> mockService = new Mock<IAuthorService>();

            // we are using the Verifiable to ensure that it runs
            mockService.Setup(m => m.GetAuthorAsync(It.IsAny<GetAuthorQuery>())).Verifiable();

            // I guess this sets up how the Mock should act
            mockService.Setup(m => m.GetAuthorAsync(It.IsAny<GetAuthorQuery>())).Returns(It.IsAny<Task<Rootobject>>());

            var expected = It.IsAny<Task<Rootobject>>();

            // Act
            var result = mockService.Object.GetAuthorAsync(It.IsAny<GetAuthorQuery>());

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
