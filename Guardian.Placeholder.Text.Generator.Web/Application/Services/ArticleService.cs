using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Articles;
using Guardian.Text.Generator.Web.Extensions;
using Guardian.Text.Generator.Web.Infrastructure.Api;
using Guardian.Text.Generator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Services
{
    public class ArticleService : IArticleService
    {
        public async Task<Article> GetArticlesAsync(GetAllArticlesQuery query)
        {
            var result = await ApiService.SendRequestAndGetArticles(query.Author);

            Article article = GetArticlesWithCorrectAuthor(query, result);

            if (article == null)
            {
                return await GetArticlesAsync(query);
            }
            return article;
        }

        private static Article GetArticlesWithCorrectAuthor(GetAllArticlesQuery query, Rootobject result)
        {
            List<Article> articlesWithAuthorInfo = new List<Article>();

            foreach (var articleResponse in result.response.results)
            {
                if (HasAuthorInfo(articleResponse))
                {
                    articlesWithAuthorInfo.Add(articleResponse);
                }
            };

            var articles = from a in articlesWithAuthorInfo
                           where IsArticleAuthorEqualToQueryAuthor(query, a) && IsArticleTypeEqualToArticle(a)
                           select a;

            var articleArray = articles.ToArray();
            Random rnd = new Random();
            var randomIndex = rnd.Next(0, articleArray.Length);
            var article = articleArray[randomIndex];

            if (article == null)
                return null;

            return article;
        }

        private static bool IsArticleTypeEqualToArticle(Article a)
        {
            return a.type.ToLowerAndTrim() == "article";
        }

        private static bool IsArticleAuthorEqualToQueryAuthor(GetAllArticlesQuery query, Article a)
        {
            return a.tags[0].webTitle.ToLowerAndTrim() == query.Author.ToLowerAndTrim();
        }

        private static bool HasAuthorInfo(Article articleResponse)
        {
            return articleResponse.tags.Length > 0;
        }
    }
}
