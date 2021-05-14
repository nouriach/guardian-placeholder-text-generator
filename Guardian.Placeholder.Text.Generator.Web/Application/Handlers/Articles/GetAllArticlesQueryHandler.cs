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
            var articles = await _service.GetArticlesAsync(request);
            var article = GetSingleRandomArticle(articles);
            var content = await _webscrapeService.GetPageContentAsync(article.webUrl);

            int count = Convert.ToInt32(request.RequestCount);

            if (request.IsWordRequest)
            {
                GetWordRequestResult result = new GetWordRequestResult(content, count);
                _result = new GetContentResult(result);
            }
            if (!request.IsWordRequest)
            {
                GetCharacterRequestResult result = new GetCharacterRequestResult(content, count);
                _result = new GetContentResult(result);
            }

            return _result;
        }

        private static Article GetSingleRandomArticle(Rootobject articles)
        {
            Random _rand = new Random();
            var allArticles = articles.response.results;
            var articlesCount= articles.response.results.Length;
            var randomArticleIndex = _rand.Next(0, articlesCount);
            return allArticles[randomArticleIndex];
        }
    }
}
