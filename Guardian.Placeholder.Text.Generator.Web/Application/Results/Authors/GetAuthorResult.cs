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
        public GetAuthorResult(Rootobject author)
        {
            AuthorName = author.response.results[0].tags[0].webTitle;
            Url = author.response.results[0].tags[0].webUrl;
            Bio = RemoveHtml(author.response.results[0].tags[0].bio);
            AuthorImageSmall = author.response.results[0].tags[0].bylineImageUrl;
            AuthorImageLarge = author.response.results[0].tags[0].bylineLargeImageUrl;
            FirstName = author.response.results[0].tags[0].firstName;
            LastName = author.response.results[0].tags[0].lastName;
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
