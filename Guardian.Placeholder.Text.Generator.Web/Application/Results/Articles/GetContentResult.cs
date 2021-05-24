

using Guardian.Text.Generator.Web.Models;

namespace Guardian.Text.Generator.Web.Application.Results.Articles
{
    public class GetContentResult : BaseResult
    {
        public GetContentResult(GetWordRequestResult result, Bio author)
        {
            Content = result.Content;
            AuthorInfo = new Author
            {
                FullName = author.webTitle,
                Bio = author.bio,
                BylineImageUrl = author.bylineImageUrl,
                BylineLargeImageUrl = author.bylineLargeImageUrl,
                FirstName = author.firstName,
                LastName = author.lastName,
                Url = author.webUrl
            };
        }

        public GetContentResult(GetCharacterRequestResult result, Bio author)
        {
            Content = result.Content;
            AuthorInfo = new Author
            {
                FullName = author.webTitle,
                Bio = author.bio,
                BylineImageUrl = author.bylineImageUrl,
                BylineLargeImageUrl = author.bylineLargeImageUrl,
                FirstName = author.firstName,
                LastName = author.lastName
            };
        }
    }
}
