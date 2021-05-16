using Guardian.Text.Generator.Web.Extensions;
using Guardian.Text.Generator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Results.Authors
{
    public class GetAuthorResult
    {
        public GetAuthorResult(Article author)
        {
            AuthorName = author.tags[0].webTitle;
            Url = author.tags[0].webUrl;
            Bio = RemoveHtml(author.tags[0].bio);
            AuthorImageSmall = author.tags[0].bylineImageUrl;
            AuthorImageLarge = author.tags[0].bylineLargeImageUrl;
            FirstName = author.tags[0].firstName;
            LastName = author.tags[0].lastName;
        }

        private string RemoveHtml(string bio)
        {
            return bio.RemoveHtmlFromString();
        }

        public string AuthorName { get; set; }
        public string Url { get; set; }
        public string Bio { get; set; }
        public string AuthorImageSmall { get; set; }
        public string AuthorImageLarge { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
