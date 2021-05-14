using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Application.Results.Authors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Handlers.Authors
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, GetAuthorResult>
    {
        public Task<GetAuthorResult> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
