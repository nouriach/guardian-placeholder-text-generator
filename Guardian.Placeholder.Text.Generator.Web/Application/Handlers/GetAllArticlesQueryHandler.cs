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


        private static string _placeholderText;

        public GetAllArticlesQueryHandler(IArticleService service)
        {
            _service = service;
        }

        // This should return a ViewModel
        public async Task<string> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {

            // Single Responsibility: have the below been separated into new classes?
            SetCharacterCountRequest(Convert.ToInt32(request.CharacterCount));

            _articles = _service.GetArticlesAsync(request).Result;
           
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
