using Guardian.Text.Generator.Web.Application.Results;
using Guardian.Text.Generator.Web.Application.Results.Articles;

namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class ContentResultViewModel
    {
        public ContentResultViewModel()
        {

        }
        public ContentResultViewModel(GetContentResult result)
        {
            Content = result.Content;
        }
        public string Content { get; }
    }
}
