using Guardian.Text.Generator.Web.Application.Handlers;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Guardian.Text.Generator.Web.Application.Services;
using Guardian.Text.Generator.Web.Application.Handlers.Articles;
using Guardian.Text.Generator.Web.Application.Queries.Articles;
using Guardian.Text.Generator.Web.Application.Results.Articles;

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
        [TestCase("350", true)]
        [TestCase("250", true)]
        [TestCase("100", false)]
        [TestCase("300", true)]
        [TestCase("150", true)]
        [TestCase("200", false)]
        public async Task QueryHandler_ReceivesQuery_ThenResultIsReturnedFromService_AndIsContentResult(string requestCount, bool isWordRequest)
        {
            // Arrange

            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                RequestCount = requestCount,
                IsWordRequest = isWordRequest
            };

            IArticleService serv = new ArticleService();
            IWebscrapeService scrapeServe = new WebscrapeService();
            GetAllArticlesQueryHandler sut = new GetAllArticlesQueryHandler(serv, scrapeServe);

            // Act
            var result = await sut.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsInstanceOf<GetContentResult>(result);
        }

        [Test]
        [TestCase("350", false)]
        [TestCase("250", false)]
        [TestCase("100", false)]
        [TestCase("300", false)]
        [TestCase("150", false)]
        [TestCase("200", false)]
        public async Task QueryHandler_ReceivesCharacterRequestQuery_ThenResultIsReturnedFromService_AndIsSameLengthAsRequest(string characterCount, bool isNotWordRequest)
        {
            // Arrange

            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                RequestCount = characterCount,
                IsWordRequest = isNotWordRequest
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
        [TestCase("350", true)]
        [TestCase("250", true)]
        [TestCase("100", true)]
        [TestCase("300", true)]
        [TestCase("150", true)]
        [TestCase("200", true)]
        public async Task QueryHandler_ReceivesWordRequestQuery_ThenResultIsReturnedFromService_AndIsSameLengthAsRequest(string characterCount, bool isWordRequest)
        {
            // Arrange

            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                RequestCount = characterCount,
                IsWordRequest = isWordRequest
            };

            IArticleService serv = new ArticleService();
            IWebscrapeService scrapeServe = new WebscrapeService();
            GetAllArticlesQueryHandler sut = new GetAllArticlesQueryHandler(serv, scrapeServe);

            // Act
            var expected = Convert.ToInt32(characterCount);
            var result = await sut.Handle(query, CancellationToken.None);
            var actual = result.Content.Split(" ");
            
            // Assert
            Assert.AreEqual(expected, actual.Length);
        }

        [Test]
        public void QueryHandler_TakesArticleServiceInConstructor_CallsArticleServiceMethod()
        {
            GetAllArticlesQuery query = new GetAllArticlesQuery();

            GetAllArticlesQueryHandler sut = InstantiateQueryHandlerWithInterface();

            var result = sut.Handle(query, CancellationToken.None);

            _mockService.Verify(m => m.GetArticlesAsync(It.IsAny<GetAllArticlesQuery>()), Times.Once);
        }
    }
}
