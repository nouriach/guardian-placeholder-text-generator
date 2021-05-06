using AngleSharp;
using Guardian.Placeholder.Text.Generator.Web.Models;
using Guardian.Text.Generator.Web.Models;
using Guardian.Text.Generator.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guardian.Placeholder.Text.Generator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static readonly string _htmlRegex = "[<][^<>]*[>]";

        public static Rootobject _articles;
        public static Article _article;

        public static List<string> _copy;


        public static int _characterCountRequest;

        public static string _urlBase = "https://content.guardianapis.com/search?";
        public static int _page;
        public static string _pageRequest = $"page=";
        public static string _query = "q=barney-ronay";
        public static string _queryDate = "from-date=2018-01-01";
        public static string _apiKey = "api-key=0ff89a23-392e-4b15-ad61-da8b70a6abd1";

        public static string _placeholderText;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            // var result = await GetPageData("https://www.theguardian.com/football/2021/mar/27/harry-kane-shuts-out-noise-to-fix-focus-pivotal-summer-england-euros");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CharacterSubmission req)
        {
            // Make the API Call
            SetCharacterCountRequest(Convert.ToInt32(req.Count));
            GetRandomPageNumber();
            var jsonString = await SendGuardianRequest(BuildApiCall());
            MapJsonToArticleModel(jsonString);
            SelectRandomSingleArticleFromCollection();

            // Use the result of the API call to web scrape content
            var content = await GetPageData(_article.webUrl);

            // Build the content to match the length of the character request
            BuildPlaceHolderText(content);

            // Make a new View Model
            ContentResultViewModel crvm = new ContentResultViewModel(_placeholderText);
            AuthorViewModel avm = new AuthorViewModel("Nathan");
            HomepageViewModel hvm = new HomepageViewModel(null, null, null);

            return RedirectToAction("PlaceholderResult", hvm);
        }

        public IActionResult PlaceholderResult(ContentResultViewModel vm)
        {
            return View(vm);
        }

        // MAKING THE API CALL
        public static void SetCharacterCountRequest(int count)
        {
            _characterCountRequest = count;
        }
        public static void GetRandomPageNumber()
        {
            Random rand = new Random();
            _page = rand.Next(1, 10);
        }
        public static string BuildApiCall()
        {
            var url = $"{_urlBase}{_pageRequest}{_page}&{_query}&{_queryDate}&{_apiKey}";
            return url;
        }
        public static async Task<string> SendGuardianRequest(string url)
        {
            // need to add some sort of check on the success status
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync(url);
            return result;
        }
        public static void MapJsonToArticleModel(string content)
        {
            _articles = JsonConvert.DeserializeObject<Rootobject>(content);
        }
        public static void SelectRandomSingleArticleFromCollection()
        {
            Random rand = new Random();
            _article = _articles.response.results[rand.Next(0, _articles.response.results.Length)];
        }


        // WEBSCRAPING AN ARTICLE
        public static async Task<List<string>> GetPageData(string url)
        {
            _copy = new List<string>();

            // Load default configuration
            var config = Configuration.Default.WithDefaultLoader();
            // Create a new browsing context
            var context = BrowsingContext.New(config);
            // This is where the HTTP request happens, returns <IDocument> that // we can query later
            var document = await context.OpenAsync(url);

            var articleCopyRows = document.QuerySelectorAll("p");

            foreach (var copy in articleCopyRows)
            {
                if (!string.IsNullOrEmpty(copy.InnerHtml) && !copy.InnerHtml.Contains("modified"))
                {
                    var result = CheckIfCopyContainsHtml(copy.InnerHtml) ? RemoveHtmlFromCopy(copy.InnerHtml) : copy.InnerHtml;
                    _copy.Add(result);
                }
            }

            return _copy;
        }


        public static bool CheckIfCopyContainsHtml(string copy)
        {
            if (Regex.IsMatch(copy, _htmlRegex))
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        public static string RemoveHtmlFromCopy(string innerHtml)
        {
            string cleanedCopy = Regex.Replace(innerHtml, _htmlRegex, "").Trim();
            return cleanedCopy;
        }

        // Build Placeholder Text
        public static void BuildPlaceHolderText(List<string> result)
        {
            StringBuilder buildCopy = new StringBuilder();
            int count = 0;

            foreach(var sentence in result)
            {
                var characters = sentence.ToCharArray();
                foreach (var ch in characters)
                {
                    if(count < _characterCountRequest)
                    {
                        count++;
                        buildCopy.Append(ch);
                        if (ch.ToString() == "." || ch.ToString() == "!" || ch.ToString() == "?")
                        {
                            buildCopy.Append(" ");
                        }
                    }
                }
            }
            
            _placeholderText = buildCopy.ToString();
        }

        // MISC
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
