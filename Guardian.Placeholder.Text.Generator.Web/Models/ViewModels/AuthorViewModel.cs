using Guardian.Text.Generator.Web.Application.Results.Authors;
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
        public AuthorViewModel(GetAuthorResult author)
        {
            FirstName = author.FirstName;
            LastName = author.LastName;
            Url = author.Url;
            Bio = author.Bio;
            AuthorImageSmall = author.AuthorImageSmall;
            AuthorImageLarge = author.AuthorImageLarge;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Url { get; set; }
        public string Bio { get; set; }
        public string AuthorImageSmall { get; set; }
        public string AuthorImageLarge { get; set; }
    }
}
