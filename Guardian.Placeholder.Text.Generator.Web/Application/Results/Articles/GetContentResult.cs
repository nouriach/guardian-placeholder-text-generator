

namespace Guardian.Text.Generator.Web.Application.Results.Articles
{
    public class GetContentResult : BaseResult
    {
        public GetContentResult(GetWordRequestResult result)
        {
            Content = result.Content;
        }

        public GetContentResult(GetCharacterRequestResult result)
        {
            Content = result.Content;
        }
    }
}
