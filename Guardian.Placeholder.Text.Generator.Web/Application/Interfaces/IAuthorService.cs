using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<Rootobject> GetAuthorAsync(GetAuthorQuery query);

    }
}
