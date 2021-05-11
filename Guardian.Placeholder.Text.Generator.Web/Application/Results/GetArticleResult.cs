using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Application.Results
{
    public class GetArticleResult
    {
        public GetArticleResult(List<string> contentCollection, int characterCount)
        {
            Content = BuildContent(contentCollection, characterCount);
        }

        public string Content { get; }
        private string BuildContent(List<string> contentCollection, int characterCount)
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
