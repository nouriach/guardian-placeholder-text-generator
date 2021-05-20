using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Articles;
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
            List<Article> test = new List<Article>();
            
            foreach(var t in result.response.results)
            {
                if (t.tags.Length > 0)
                {
                    test.Add(t);
                }
            };

            var articles = from t in test
                                 where t.tags[0].webTitle.ToLower().Trim() == query.Author.ToLower().Trim()
                                 select t;

            var articleArray = articles.ToArray();
            Random rnd = new Random();
            var randomIndex = rnd.Next(0, articleArray.Length);
            var article = articleArray[randomIndex];

            if (article == null)
                return null;

            return article;
        }
    }
}
