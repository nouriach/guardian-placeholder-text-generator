using AngleSharp;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Articles;
using Guardian.Text.Generator.Web.Application.Results.Articles;
using Guardian.Text.Generator.Web.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Handlers.Articles
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, GetContentResult>
    {
        private readonly IArticleService _service;
        private readonly IWebscrapeService _webscrapeService;
        private static GetContentResult _result;

        public GetAllArticlesQueryHandler(IArticleService service, IWebscrapeService webscrapeService)
        {
            _service = service;
            _webscrapeService = webscrapeService;
        }

        public async Task<GetContentResult> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var article = await _service.GetArticlesAsync(request);
            var author = article.tags[0];
            //var article = GetSingleRandomArticle(articles);
            var content = await _webscrapeService.GetPageContentAsync(article.webUrl);
            int count = Convert.ToInt32(request.RequestCount);

            if (request.IsWordRequest)
            {
                // article.tags[] should be passed into these controllers
                // then passed down to the GetContentResult base class
                // then assigned to an Author property
                // then on being return to the Home Controller, the Author property can be sent to an AuthorVM
                GetWordRequestResult result = new GetWordRequestResult(content, count);
                _result = new GetContentResult(result, author);
            }
            if (!request.IsWordRequest)
            {
                GetCharacterRequestResult result = new GetCharacterRequestResult(content, count);
                _result = new GetContentResult(result, author);
            }

            return _result;
        }
    }
}
