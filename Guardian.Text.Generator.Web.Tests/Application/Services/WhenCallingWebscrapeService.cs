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
        public static void WithArticleObject_ThenScrapePage_AndReturnsStringCollection()
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
    }
}
