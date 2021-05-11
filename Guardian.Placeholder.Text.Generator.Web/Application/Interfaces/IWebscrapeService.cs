using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Interfaces
{
    public interface IWebscrapeService
    {
        Task<List<string>> GetPageContentAsync(string articleLink);
    }
}
