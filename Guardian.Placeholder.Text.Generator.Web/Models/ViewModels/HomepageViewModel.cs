using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class HomepageViewModel
    {
        public HomepageViewModel(AuthorViewModel author, ContentRequestViewModel request, ContentResultViewModel result)
        {
            Author = author;
            ContentRequest = request;
            ContentResult = result;
        }

        public AuthorViewModel Author { get; }
        public ContentRequestViewModel ContentRequest { get; }
        public ContentResultViewModel ContentResult { get; }

    }
}
