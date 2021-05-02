using Guardian.Text.Generator.Web.Application.Queries;
using Guardian.Text.Generator.Web.Models;
using Guardian.Text.Generator.Web.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Controllers
{
    public class PlaceholderController : Controller
    {
        private readonly IMediator _mediator;

        public PlaceholderController(IMediator mediator)
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
                CharacterCount = req.Request
            };

            var result = await _mediator.Send(query, CancellationToken.None);

            ContentResultViewModel cvm = new ContentResultViewModel(result);

            HomepageViewModel vm = new HomepageViewModel(null, null, cvm);

            return View(vm);
        }
    }
}
