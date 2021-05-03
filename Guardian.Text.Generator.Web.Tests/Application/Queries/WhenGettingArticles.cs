﻿using Guardian.Text.Generator.Web.Application.Handlers;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries;
using Guardian.Text.Generator.Web.Models;
using Moq;
using AutoFixture;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework;
using AutoFixture.Xunit2;
using Guardian.Text.Generator.Web.Application.Services;

namespace Guardian.Text.Generator.Web.Tests.Application.Queries
{
    public class WhenGettingArticles
    {
        //Arrange
        //Act
        //Assert

        private Mock<IArticleService> _mockService;

        private GetAllArticlesQueryHandler InstantiateQueryHandler()
        {
            _mockService = new Mock<IArticleService>();
            var sut = new GetAllArticlesQueryHandler(_mockService.Object);
            return sut;
        }

        [Test]
        [TestCase("350")]
        [TestCase("250")]
        [TestCase("100")]
        [TestCase("300")]
        [TestCase("150")]
        [TestCase("200")]
        public void QueryHandler_ReceivesQuery_ThenResultIsReturnedFromService_AndIsString(string characterCount)
        {
            // Arrange
            IArticleService serv = new ArticleService();
            GetAllArticlesQueryHandler sut = new GetAllArticlesQueryHandler(serv);

            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                CharacterCount = characterCount
            };

            // Act
            var result = sut.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsInstanceOf<string>(result.Result);
        }

        [Test]
        public void QueryHandler_TakesArticleServiceInConstructor_CallsArticleServiceMethod()
        {
            GetAllArticlesQuery query = new GetAllArticlesQuery();

            GetAllArticlesQueryHandler sut = InstantiateQueryHandler();

            var result = sut.Handle(query, CancellationToken.None);
            Rootobject expected = new Rootobject();

            _mockService.Verify(m => m.GetArticlesAsync(It.IsAny<GetAllArticlesQuery>()), Times.Once);
        }

        // Next test will check that the AuthorService has called and brought back the author
    }
}