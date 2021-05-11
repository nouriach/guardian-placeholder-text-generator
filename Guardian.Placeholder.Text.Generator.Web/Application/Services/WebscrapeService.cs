using AngleSharp;
using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Extensions;
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
            // This is where the HTTP request happens, returns <IDocument> that // we can query later
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
            return copy;
        }

        private static void RemoveArticleSubHeading(List<string> copy)
        {
            copy.RemoveAt(0);
        }
    }
}
