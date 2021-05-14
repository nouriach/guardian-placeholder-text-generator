using Guardian.Text.Generator.Web.Application.Results;
using Guardian.Text.Generator.Web.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Queries
{
    public class GetAllArticlesQuery : IRequest<GetContentResult>
    {
        public string RequestCount { get; set; }
        public bool IsWordRequest { get; set; }
    }
}
