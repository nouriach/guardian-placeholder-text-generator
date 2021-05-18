using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Services;
using Guardian.Text.Generator.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Tests.Application.Services
{
    public class WhenCallingWebscrapeService
    {
        // Arrange
        // Act
        // Assert

        [Test]
        public static void WithUrl_ThenScrapePageForArticleContent_AndReturnStringCollection()
        {
            // Arrange
            Article article = new Article()
            {
                webUrl = "https://www.theguardian.com/football/2021/may/08/sergio-agueros-rush-of-blood-gives-thomas-tuchel-a-day-to-savour"
            };

            IWebscrapeService sut = new WebscrapeService();

            // Act
            var result = sut.GetPageContentAsync(article.webUrl);

            // Assert
            Assert.IsInstanceOf<Task<List<string>>>(result);
        }

        [Test]
        public static void ThenScrapePageForAuthorsContent_AndReturnStringCollection()
        {
            // Arrange

            IWebscrapeService sut = new WebscrapeService();

            // Act
            var result = sut.GetAllAuthorsAsync();

            // Assert
            Assert.IsInstanceOf<Task<List<string>>>(result);
        }
    }
}
