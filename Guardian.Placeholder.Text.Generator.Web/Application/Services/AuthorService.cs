using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Models;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Services
{
    public class AuthorService : IAuthorService
    {
        public Task<Author> GetAuthorAsync(GetAuthorQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
