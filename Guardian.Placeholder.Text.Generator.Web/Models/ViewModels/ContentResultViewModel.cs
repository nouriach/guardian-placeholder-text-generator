using Guardian.Text.Generator.Web.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class ContentResultViewModel
    {
        public ContentResultViewModel()
        {

        }
        public ContentResultViewModel(GetArticleResult result)
        {
            Content = result.Content;
        }
        public string Content { get; }
    }
}
