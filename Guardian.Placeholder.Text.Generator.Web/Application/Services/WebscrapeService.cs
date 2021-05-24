using AngleSharp;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Extensions;
using Guardian.Text.Generator.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Services
{
    public class WebscrapeService : IWebscrapeService
    {
        public async Task<List<string>> GetPageContentAsync(string articleLink)
        {
            List<string> copy = new List<string>();

            // Load default configuration
            var config = Configuration.Default.WithDefaultLoader();
            // Create a new browsing context
            var context = BrowsingContext.New(config);
            // This is where the HTTP request happens, returns <IDocument> that we can query later
            var document = await context.OpenAsync(articleLink);

            var articleCopyRows = document.QuerySelectorAll("p");

            foreach (var c in articleCopyRows)
            {
                if (!string.IsNullOrEmpty(c.InnerHtml) && !c.InnerHtml.Contains("modified"))
                {

                    var result = c.InnerHtml.CheckIfCopyContainsHtml() ? c.InnerHtml.RemoveHtmlFromString() : c.InnerHtml;
                    copy.Add(result);
                }
            }

            RemoveArticleSubHeading(copy);
            RemoveArticleCssContent(copy);
            return copy;
        }

        private void RemoveArticleCssContent(List<string> copy)
        {
            copy.RemoveAt(0);
        }

        private static void RemoveArticleSubHeading(List<string> copy)
        {
            copy.RemoveAt(0);
        }

        public async Task<List<string>> GetAllAuthorsAsync()
        {
            var url = "https://www.theguardian.com/index/contributors";

            List<string> copy = new List<string>();

            // Load default configuration
            var config = Configuration.Default.WithDefaultLoader();
            // Create a new browsing context
            var context = BrowsingContext.New(config);
            // This is where the HTTP request happens, returns <IDocument> that we can query later
            var document = await context.OpenAsync(url);

            var authors = document.GetElementById("sport").GetElementsByClassName("fc-item fc-item--list-compact");

            foreach (var c in authors)
            {
                copy.Add(c.FirstElementChild.InnerHtml);
            }
            SortCollectionIntoAlphabeticalOrder ss = new SortCollectionIntoAlphabeticalOrder();
            copy.Sort(ss);
            return copy;
        }
    }
}
