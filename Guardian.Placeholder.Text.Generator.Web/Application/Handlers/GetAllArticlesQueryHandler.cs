using AngleSharp;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Queries;
using Guardian.Text.Generator.Web.Models;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Handlers
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, string>
    {
        private readonly IArticleService _service;

        private static readonly string _htmlRegex = "[<][^<>]*[>]";

        private static Rootobject _articles;
        private static Article _article;

        private static List<string> _copy;

        private static int _characterCountRequest;

        // Can this all be stored like in the below
        // https://github.com/nouriach/Police_Data_Api/blob/master/policeDataApi_Practice/Startup.cs
        // https://github.com/nouriach/Police_Data_Api/blob/master/policeDataApi_Practice/appsettings.json

        private static string _urlBase = "https://content.guardianapis.com/search?";
        private static int _page;
        private static string _pageRequest = $"page=";
        private static string _query = "q=barney-ronay";
        private static string _queryDate = "from-date=2018-01-01";
        private static string _apiKey = "api-key=0ff89a23-392e-4b15-ad61-da8b70a6abd1";

        private static string _placeholderText;

        public GetAllArticlesQueryHandler(IArticleService service)
        {
            _service = service;
        }

        // This should return a ViewModel
        public async Task<string> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {

            // Single Responsibility: have the below been separated into new classes?

            // Make the API call
            SetCharacterCountRequest(Convert.ToInt32(request.CharacterCount));
            GetRandomPageNumber();
            var jsonString = await SendGuardianRequest(BuildApiCall());
            MapJsonToArticleModel(jsonString);
           
            // Get a single article
            SelectRandomSingleArticleFromCollection();

            // Use the result of the API call to web scrape content
            var content = await GetPageData(_article.webUrl);

            // Build the content to match the length of the character request
            BuildPlaceHolderText(content);

            // Make a new View Model to return?
            return _placeholderText;
        }
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

        public static void BuildPlaceHolderText(List<string> result)
        {
            StringBuilder buildCopy = new StringBuilder();
            int count = 0;

            foreach (var sentence in result)
            {
                var characters = sentence.ToCharArray();
                foreach (var ch in characters)
                {
                    if (count < _characterCountRequest)
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
    }
}
