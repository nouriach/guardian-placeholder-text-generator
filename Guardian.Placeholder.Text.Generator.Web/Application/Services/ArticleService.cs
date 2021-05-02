using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries;
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

        public async Task<Rootobject> GetArticlesAsync(GetAllArticlesQuery query)
        {
            var result = await ApiService.SendRequestAndGetArticles();
            return result;
        }
    }
}
