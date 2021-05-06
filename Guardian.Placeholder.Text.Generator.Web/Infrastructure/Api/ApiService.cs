using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Infrastructure.Api
{

    public static class ApiService
    {

        // Can this all be stored like in the below
        // https://github.com/nouriach/Police_Data_Api/blob/master/policeDataApi_Practice/Startup.cs
        // https://github.com/nouriach/Police_Data_Api/blob/master/policeDataApi_Practice/appsettings.json

        private static Rootobject _articles;

        private static string _urlBase = "https://content.guardianapis.com/search?";
        private static int _page;
        private static string _pageRequest = $"page=";
        private static string _query = "q=barney-ronay";
        private static string _queryDate = "from-date=2018-01-01";
        private static string _apiKey = "api-key=0ff89a23-392e-4b15-ad61-da8b70a6abd1";

        public static async Task<Rootobject> SendRequestAndGetArticles()
        {
            GetRandomPageNumber();
            var jsonString = await SendGuardianRequest(BuildApiCall());
            MapJsonToArticleModel(jsonString);
            return _articles;
        }

        private static void GetRandomPageNumber()
        {
            Random rand = new Random();
            _page = rand.Next(1, 10);
        }

        private static string BuildApiCall()
        {
            var url = $"{_urlBase}{_pageRequest}{_page}&{_query}&{_queryDate}&{_apiKey}";
            return url;
        }

        private static async Task<string> SendGuardianRequest(string url)
        {
            // need to add some sort of check on the success status
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync(url);
            return result;
        }

        private static void MapJsonToArticleModel(string content)
        {
            _articles = JsonConvert.DeserializeObject<Rootobject>(content);
        }

    }
}
