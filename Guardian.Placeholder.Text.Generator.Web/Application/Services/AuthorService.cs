using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Infrastructure.Api;
using Guardian.Text.Generator.Web.Models;
using System;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Services
{
    public class AuthorService : IAuthorService
    {
        public async Task<Rootobject> GetAuthorAsync(GetAuthorQuery query)
        {
            var result = await ApiService.SendRequestAndGetAuthorBio(query.Name);
            return result;
        }
    }
}
