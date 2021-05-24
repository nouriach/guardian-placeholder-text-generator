using Guardian.Text.Generator.Web.Application.Results.Authors;
using Guardian.Text.Generator.Web.Extensions;
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
        public AuthorViewModel(Author author)
        {
            FirstName = author.FirstName ?? null;
            LastName = author.LastName ?? null;
            Url = author.Url ?? null;
            Bio = author.Bio.RemoveNonBreakingSpaceFromString().RemoveHtmlFromString() ?? null;
            AuthorImageSmall = author.BylineImageUrl ?? null;
            AuthorImageLarge = author.BylineLargeImageUrl ?? null;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Url { get; set; }
        public string Bio { get; set; }
        public string AuthorImageSmall { get; set; }
        public string AuthorImageLarge { get; set; }
    }
}
