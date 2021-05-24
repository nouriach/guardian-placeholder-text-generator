using Guardian.Text.Generator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Results.Articles
{
    public class BaseResult
    {
        public string Content { get; set; }
        public Author AuthorInfo { get; set; }
    }
}
