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
        private static Random _rand = new Random();

        private static readonly string _htmlRegex = "[<][^<>]*[>]";

        public GetAllArticlesQueryHandler(IArticleService service)
        {
            _service = service;
        }

        // This should return a ViewModel
        public async Task<string> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            int characterCount = Convert.ToInt32(request.CharacterCount);

            var articles = await _service.GetArticlesAsync(request);

            var article = articles.response.results[_rand.Next(0, articles.response.results.Length)];

            // Use the result of the API call to web scrape content
            // articlePageContent = await _webscrapeService.GetContent();
            var content = await GetPageData(article.webUrl);

            // Build the content to match the length of the character request
            // Result r = new Result(content, characterCount);
                // constructor will deal with it
            // return r;
            string _placeholderText = BuildPlaceHolderText(content, characterCount);

            // Make a new View Model to return?
            return _placeholderText;
        }

        // WEBSCRAPING AN ARTICLE
        public static async Task<List<string>> GetPageData(string url)
        {
            List<string> copy = new List<string>();

            // Load default configuration
            var config = Configuration.Default.WithDefaultLoader();
            // Create a new browsing context
            var context = BrowsingContext.New(config);
            // This is where the HTTP request happens, returns <IDocument> that // we can query later
            var document = await context.OpenAsync(url);

            var articleCopyRows = document.QuerySelectorAll("p");

            foreach (var c in articleCopyRows)
            {
                if (!string.IsNullOrEmpty(c.InnerHtml) && !c.InnerHtml.Contains("modified"))
                {
                    var result = CheckIfCopyContainsHtml(c.InnerHtml) ? RemoveHtmlFromCopy(c.InnerHtml) : c.InnerHtml;
                    copy.Add(result);
                }
            }

            return copy;
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

        public string BuildPlaceHolderText(List<string> result, int maxCount)
        {
            StringBuilder buildCopy = new StringBuilder();
            int count = 0;

            foreach (var sentence in result)
            {
                var characters = sentence.ToCharArray();
                foreach (var ch in characters)
                {
                    if (buildCopy.ToString().Length < maxCount)
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

            return buildCopy.ToString();
        }
    }
}
