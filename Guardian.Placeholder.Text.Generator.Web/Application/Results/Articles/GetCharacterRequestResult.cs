using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Results.Articles
{
    public class GetCharacterRequestResult : BaseResult
    {
        public GetCharacterRequestResult(List<string> contentCollection, int characterCount)
        {
            Content = BuildContentBasedOnCharacterCount(contentCollection, characterCount);
        }

        private string BuildContentBasedOnCharacterCount(List<string> contentCollection, int characterCount)
        {
            StringBuilder buildCopy = new StringBuilder();

            foreach (var sentence in contentCollection)
            {
                var characters = sentence.ToCharArray();
                foreach (var ch in characters)
                {
                    if (buildCopy.ToString().Length < characterCount)
                    {
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
