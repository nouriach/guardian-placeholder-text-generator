using Guardian.Placeholder.Text.Generator.Web.Models;
using Guardian.Text.Generator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guardian.Placeholder.Text.Generator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly string _htmlRegex = "[<][^<>]*[>]";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CharacterSubmission value)
        {
            // 1. Select random number to act as the 'page' number
            // 2. Make API call to all adding random page number
            // 3. Store all results into a match JSON model
            // 4. This will result in a List<JSONModel> holding 10 values
            // 5. Select a random entry from this collection
            // 6. grab the apiLink for that value
            // 7. Use AngleSharp to webscrape this page
            // 8. After grabbing and storing all <p> elements clean them all with the Regex
            // 9. Add each entry from the cleaned copy array until length matches the initial character count value

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static string RemoveHtmlFromCopy(string innerHtml)
        {
            string cleanedCopy = Regex.Replace(innerHtml, _htmlRegex, "").Trim();
            return cleanedCopy;
        }

    }
}
