using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {

        }
        public AuthorViewModel(string name)
        {
            FirstName = name;
        }

        public string FirstName { get; set; }
    }
}
