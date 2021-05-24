using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Infrastructure.Api;
using Guardian.Text.Generator.Web.Models;
using System;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Services
{
    public class AuthorService : IAuthorService
    {
        public async Task<Article> GetAuthorAsync(GetAuthorQuery query)
        {
            var result = await ApiService.SendRequestAndGetAuthorBio(query.Name);
            foreach (var value in result.response.results)
            {
                if (GetResponseAuthorName(value) == query.Name.ToLower().Trim())
                {
                    Article article = new Article();
                    article = value;
                    return article;
                }
            }
            return null;
        }

        private static string GetResponseAuthorName(Article value)
        {
            if (value.tags.Length > 0)
            {
                return value.tags[0].webTitle.ToLower().Trim();
            }
            return null;
        }
    }
}
