using Guardian.Text.Generator.Web.Application.Handlers.Authors;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Application.Services;
using Guardian.Text.Generator.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Tests.Application.Handlers
{
    public class WhenUsingGetAuthorQueryHandler
    {
        //Arrange
        //Act
        //Assert

        private IAuthorService _mockService;

        [Test]
        public async Task QueryHandler_ReceivesQuery_ThenResultIsReturnedFromService()
        {
            //Arrange
            GetAuthorQuery query = new GetAuthorQuery()
            {
                Name = "Barney Ronay"
            };

            _mockService = new AuthorService();
            GetAuthorQueryHandler handler = new GetAuthorQueryHandler(_mockService);

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsInstanceOf<GetAuthorResult>(result);
        }

        [Test]
        public async Task QueryHandler_ReceivesQuery_ResultIsReturned_WithCorrectAuthor()
        {
            //Arrange
            GetAuthorQuery query = new GetAuthorQuery()
            {
                Name = "Barney Ronay"
            };

            _mockService = new AuthorService();
            GetAuthorQueryHandler handler = new GetAuthorQueryHandler(_mockService);

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(query.Name, result.AuthorName);
        }
    }
}
