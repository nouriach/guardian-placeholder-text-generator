using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Application.Results.Authors;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Handlers.Authors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, GetAuthorsResult>
    {
        private readonly IWebscrapeService _service;

        public GetAllAuthorsQueryHandler(IWebscrapeService service)
        {
            _service = service;
        }
        public async Task<GetAuthorsResult> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var response = await _service.GetAllAuthorsAsync();
            GetAuthorsResult result = new GetAuthorsResult(response);

            return result;
        }
    }
}
