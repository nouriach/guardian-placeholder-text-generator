using Guardian.Text.Generator.Web.Application.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Results
{
    public class GetContentResult : BaseResult
    {
        public GetContentResult(GetWordRequestResult result)
        {
            Content = result.Content;
        }

        public GetContentResult(GetCharacterRequestResult result)
        {
            Content = result.Content;
        }
    }
}
