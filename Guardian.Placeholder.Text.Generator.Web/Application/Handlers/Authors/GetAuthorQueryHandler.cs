using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Application.Results.Authors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Handlers.Authors
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, GetAuthorResult>
    {
        private readonly IAuthorService _service;

        public GetAuthorQueryHandler(IAuthorService service)
        {
            _service = service;
        }
        public async Task<GetAuthorResult> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _service.GetAuthorAsync(request);
            GetAuthorResult result = new GetAuthorResult(author);
            return result;
        }
    }
}
