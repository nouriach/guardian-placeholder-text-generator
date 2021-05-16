using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models
{
    public class Rootobject
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public string status { get; set; }
        public string userTier { get; set; }
        public int total { get; set; }
        public int startIndex { get; set; }
        public int pageSize { get; set; }
        public int currentPage { get; set; }
        public int pages { get; set; }
        public string orderBy { get; set; }
        public Article[] results { get; set; }
    }

    public class Article
    {
        public string id { get; set; }
        public string type { get; set; }
        public string sectionId { get; set; }
        public string sectionName { get; set; }
        public DateTime webPublicationDate { get; set; }
        public string webTitle { get; set; }
        public string webUrl { get; set; }
        public string apiUrl { get; set; }
        public Bio[] tags { get; set; }
        public bool isHosted { get; set; }
        public string pillarId { get; set; }
        public string pillarName { get; set; }
    }
    public class Bio
    {
        public string id { get; set; }
        public string type { get; set; }
        public string webTitle { get; set; }
        public string webUrl { get; set; }
        public string apiUrl { get; set; }
        public object[] references { get; set; }
        public string bio { get; set; }
        public string bylineImageUrl { get; set; }
        public string bylineLargeImageUrl { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string twitterHandle { get; set; }
    }
}
