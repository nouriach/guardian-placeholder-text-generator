using Guardian.Text.Generator.Web.Application.Queries.Articles;
using Guardian.Text.Generator.Web.Application.Queries.Authors;
using Guardian.Text.Generator.Web.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Placeholder.Text.Generator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            GetAuthorQuery query = new GetAuthorQuery()
            {
                Name = "Barney Ronay"
            };

            var result = await _mediator.Send(query, CancellationToken.None);

            AuthorViewModel author = new AuthorViewModel(result);

            HomepageViewModel vm = new HomepageViewModel()
            {
                Prompt = "Choose character count",
                Author = author,
                ContentRequest = new ContentRequestViewModel(),
                ContentResult = new ContentResultViewModel()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string wordRequest, string characterRequest)
        {
            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                RequestCount = !string.IsNullOrEmpty(characterRequest) ? characterRequest : wordRequest,
                IsWordRequest = !string.IsNullOrEmpty(characterRequest) ? false : true,
            };

            var result = await _mediator.Send(query, CancellationToken.None);

            GetAuthorQuery authorQuery = new GetAuthorQuery()
            {
                Name = "Barney Ronay"
            };

            var authorResult = await _mediator.Send(authorQuery, CancellationToken.None);

            AuthorViewModel author = new AuthorViewModel(authorResult);

            ContentResultViewModel cvm = new ContentResultViewModel(result);

            HomepageViewModel vm = new HomepageViewModel(author, null, cvm);

            return View(vm);
        }

    }
}
