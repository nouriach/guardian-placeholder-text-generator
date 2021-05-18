using Guardian.Text.Generator.Web.Application.Handlers.Authors;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Application.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Tests.Application.Handlers
{
    public class WhenUsingGetAllAuthorsQueryHandler
    {
        // Arrange
        // Act
        // Assert
        private IWebscrapeService _mockService;

        [Test]
        public async Task QueryHandler_IsCalled_ThenResultIsReturnedFromService()
        {
            // Arrange
            GetAuthorsQuery query = new GetAuthorsQuery();
            _mockService = new WebscrapeService();
            GetAllAuthorsQueryHandler handler = new GetAllAuthorsQueryHandler(_mockService);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            // Assert
            Assert.IsInstanceOf<GetAuthorsResult>(result);
        }

    }
}
