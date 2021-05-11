using Guardian.Text.Generator.Web.Application.Handlers;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries;
using Guardian.Text.Generator.Web.Models;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework;
using Guardian.Text.Generator.Web.Application.Services;
using System.Collections.Generic;
using Guardian.Text.Generator.Web.Application.Results;

namespace Guardian.Text.Generator.Web.Tests.Application.Handlers
{
    public class WhenUsingGetAllArticlesQueryHandler
    {
        //Arrange
        //Act
        //Assert

        private Mock<IArticleService> _mockService;
        private Mock<IWebscrapeService> _mockWebscrapeService;

        private GetAllArticlesQueryHandler InstantiateQueryHandlerWithInterface()
        {
            _mockService = new Mock<IArticleService>();
            _mockWebscrapeService = new Mock<IWebscrapeService>();
            var sut = new GetAllArticlesQueryHandler(_mockService.Object, _mockWebscrapeService.Object);
            return sut;
        }

        [Test]
        [TestCase("350")]
        [TestCase("250")]
        [TestCase("100")]
        [TestCase("300")]
        [TestCase("150")]
        [TestCase("200")]
        public async Task QueryHandler_ReceivesQuery_ThenResultIsReturnedFromService_AndIsString(string characterCount)
        {
            // Arrange

            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                CharacterCount = characterCount
            };

            IArticleService serv = new ArticleService();
            IWebscrapeService scrapeServe = new WebscrapeService();
            GetAllArticlesQueryHandler sut = new GetAllArticlesQueryHandler(serv, scrapeServe);

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsInstanceOf<GetArticleResult>(result);
        }

        [Test]
        [TestCase("350")]
        [TestCase("250")]
        [TestCase("100")]
        [TestCase("300")]
        [TestCase("150")]
        [TestCase("200")]
        public async Task QueryHandler_ReceivesQuery_ThenResultIsReturnedFromService_AndIsSameLengthAsRequest(string characterCount)
        {
            // Arrange

            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                CharacterCount = characterCount
            };

            IArticleService serv = new ArticleService();
            IWebscrapeService scrapeServe = new WebscrapeService();
            GetAllArticlesQueryHandler sut = new GetAllArticlesQueryHandler(serv, scrapeServe);

            // Act
            var expected = Convert.ToInt32(characterCount);
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expected, result.Content.Length);
        }

        [Test]
        public void QueryHandler_TakesArticleServiceInConstructor_CallsArticleServiceMethod()
        {
            GetAllArticlesQuery query = new GetAllArticlesQuery();

            GetAllArticlesQueryHandler sut = InstantiateQueryHandlerWithInterface();

            var result = sut.Handle(query, CancellationToken.None);

            _mockService.Verify(m => m.GetArticlesAsync(It.IsAny<GetAllArticlesQuery>()), Times.Once);
        }


        // Next test will check that the AuthorService has called and brought back the author
    }
}
