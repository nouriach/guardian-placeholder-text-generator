using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Results.Authors
{
    public class GetAuthorsResult
    {
        public GetAuthorsResult()
        {

        }
        public GetAuthorsResult(List<string> authors)
        {
            Authors = authors;
        }
        public List<string> Authors { get; set; }
    }
}
