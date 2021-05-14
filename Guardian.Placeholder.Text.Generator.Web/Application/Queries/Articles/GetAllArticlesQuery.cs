using Guardian.Text.Generator.Web.Application.Results.Articles;
using MediatR;


namespace Guardian.Text.Generator.Web.Application.Queries.Articles
{
    public class GetAllArticlesQuery : IRequest<GetContentResult>
    {
        public string RequestCount { get; set; }
        public bool IsWordRequest { get; set; }
    }
}
