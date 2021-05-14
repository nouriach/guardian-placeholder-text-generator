using Guardian.Text.Generator.Web.Application.Queries;
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
        public IActionResult Index()
        {
            HomepageViewModel vm = new HomepageViewModel()
            {
                Prompt = "Choose character count",
                Author = new AuthorViewModel(),
                ContentRequest = new ContentRequestViewModel(),
                ContentResult = new ContentResultViewModel()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomepageViewModel req)
        {
            GetAllArticlesQuery query = new GetAllArticlesQuery()
            {
                RequestCount = !string.IsNullOrEmpty(req.CharacterRequest) ? req.CharacterRequest : req.WordRequest,
                IsWordRequest = !string.IsNullOrEmpty(req.CharacterRequest) ? false : true,
            };

            var result = await _mediator.Send(query, CancellationToken.None);

            ContentResultViewModel cvm = new ContentResultViewModel(result);

            HomepageViewModel vm = new HomepageViewModel(null, null, cvm);

            return View(vm);
        }

    }
}
