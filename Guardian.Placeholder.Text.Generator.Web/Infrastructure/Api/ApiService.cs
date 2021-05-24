using Guardian.Text.Generator.Web.Application.Interfaces;
using Guardian.Text.Generator.Web.Application.Results.Authors;
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
        public static Rootobject _author;

        // For content
        private static string _urlBase = "https://content.guardianapis.com/search?";
        private static int _page;
        private static string _pageRequest = $"page=";
        public static string _query = "";
        // private static string _queryDate = "from-date=2018-01-01";
        private static string _apiKey = "api-key=0ff89a23-392e-4b15-ad61-da8b70a6abd1";

        // For author bio
        // https://content.guardianapis.com/search?show-tags=contributor&section=football&q=barney-ronay&api-key=0ff89a23-392e-4b15-ad61-da8b70a6abd1

        private static string _showTags = "show-tags=contributor";
        private static string _section = "section=football";

        public static async Task<Rootobject> SendRequestAndGetArticles(string author)
        {
            SetAuthorQueryValue(author);
            // GetRandomPageNumber();
            var jsonString = await SendGuardianRequest(BuildArticleApiCall());
            MapJsonToArticleModel(jsonString);
            return _articles;
        }

        public static async Task<Rootobject> SendRequestAndGetAuthorBio(string author)
        {
            SetAuthorQueryValue(author);
            var jsonString = await SendGuardianRequest(BuildAuthorApiCall());
            MapJsonToAuthorModel(jsonString);
            return _author;
        }

        private static void SetAuthorQueryValue(string author)
        {
            var authorQuery = author.Replace(" ", "-").ToLower();
            _query = $"q={authorQuery}";
        }

    private static string BuildAuthorApiCall()
        {
            return $"{_urlBase}{_showTags}&{_section}&{_query}&{_apiKey}";
        }

        private static void GetRandomPageNumber()
        {
            Random rand = new Random();
            _page = rand.Next(1, 10);
        }

        private static string BuildArticleApiCall()
        {
            var url = $"{_urlBase}{_showTags}&{_query}&{_apiKey}";
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

        private static void MapJsonToAuthorModel(string content)
        {
            _author = JsonConvert.DeserializeObject<Rootobject>(content);
        }

    }
}
