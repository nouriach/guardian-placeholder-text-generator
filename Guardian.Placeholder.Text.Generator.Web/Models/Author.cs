using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models
{
    public class Author
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string BylineImageUrl { get; set; }
        public string BylineLargeImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Url { get; set; }
    }
}
