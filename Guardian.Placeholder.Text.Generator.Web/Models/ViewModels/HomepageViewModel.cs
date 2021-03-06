using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class HomepageViewModel
    {
        public HomepageViewModel(){}
        public string Prompt { get; set; }
        public string CharacterRequest { get; set; }
        public string WordRequest { get; set; }

        public HomepageViewModel(AuthorViewModel author, ContentRequestViewModel request, ContentResultViewModel result)
        {
            Author = author;
            ContentRequest = request;
            ContentResult = result;
        }

        public AuthorViewModel Author { get; set;  }
        public ContentRequestViewModel ContentRequest { get; set;  }
        public ContentResultViewModel ContentResult { get; set;  }

    }
}
