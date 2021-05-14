using Guardian.Text.Generator.Web.Application.Queries;
using Guardian.Text.Generator.Web.Application.Queries.Articles;
using Guardian.Text.Generator.Web.Models;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Interfaces
{
    public interface IArticleService
    {
        Task<Rootobject> GetArticlesAsync(GetAllArticlesQuery query);
    }
}
