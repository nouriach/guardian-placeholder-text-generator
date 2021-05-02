using Guardian.Text.Generator.Web.Application.Queries;
using Guardian.Text.Generator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Interfaces
{
    public interface IArticleService
    {
        Task<Rootobject> GetArticlesAsync(GetAllArticlesQuery query);
    }
}
