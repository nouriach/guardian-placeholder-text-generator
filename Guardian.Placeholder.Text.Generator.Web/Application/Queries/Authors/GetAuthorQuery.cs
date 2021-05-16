using Guardian.Text.Generator.Web.Application.Results.Authors;
using MediatR;


namespace Guardian.Text.Generator.Web.Application.Queries.Authors
{
    public class GetAuthorQuery : IRequest<GetAuthorResult>
    {
        public string Name { get; set; }

    }
}
