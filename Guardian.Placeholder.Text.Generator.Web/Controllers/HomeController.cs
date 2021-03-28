﻿using AngleSharp;
using Guardian.Placeholder.Text.Generator.Web.Models;
using Guardian.Text.Generator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guardian.Placeholder.Text.Generator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static readonly string _htmlRegex = "[<][^<>]*[>]";

        public static int _page;
        public static Rootobject _articles;
        public static Article _article;

        public static List<string> _copy;

        public static string _apiKey = "api-key=0ff89a23-392e-4b15-ad61-da8b70a6abd1";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await GetPageData("https://www.theguardian.com/football/2021/mar/27/harry-kane-shuts-out-noise-to-fix-focus-pivotal-summer-england-euros");
            return View();
        }

        [HttpPost]
        public IActionResult Index(CharacterSubmission value)
        {
            // 1. Select random number to act as the 'page' number DONE
            // 2. Make API call to all adding random page number DONE
            // 3. Store all results into a match JSON model DONE
            // 4. This will result in a List<JSONModel> holding 10 values DONE
            // 5. Select a random entry from this collection DONE
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

        public static void SelectRandomSingleArticleFromCollection()
        {
            Random rand = new Random();
            _article = _articles.response.results[rand.Next(0, _articles.response.results.Length)];
        }

        public static void MapJsonToArticleModel(string content)
        {
            _articles = JsonConvert.DeserializeObject<Rootobject>(content);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public static async Task<string> SendGuardianRequest(string url)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync($"{url}&{_apiKey}");
            return result;
        }
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
                if (CheckIfCopyContainsHtml(copy.InnerHtml))
                {
                    var result = RemoveHtmlFromCopy(copy.InnerHtml);
                    _copy.Add(result);
                }
                if (!string.IsNullOrEmpty(copy.InnerHtml) && !copy.InnerHtml.Contains("modified"))
                {
                    _copy.Add(copy.InnerHtml);
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

        public static void GetRandomPageNumber()
        {
            Random rand = new Random();
            _page = rand.Next(1, 100);
        }
    }
}
