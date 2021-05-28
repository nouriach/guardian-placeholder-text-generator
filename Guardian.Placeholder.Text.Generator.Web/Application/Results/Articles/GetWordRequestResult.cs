using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Guardian.Text.Generator.Web.Application.Results.Articles
{
    public class GetWordRequestResult : BaseResult
    {
        public GetWordRequestResult(List<string> content, int count)
        {
            Content = BuildContentBasedOnWordCount(content, count);
        }
        private string BuildContentBasedOnWordCount(List<string> content, int count)
        {
            StringBuilder buildCopy = new StringBuilder();

            List<string> finalCopy = new List<string>();
            foreach (var sentence in content)
            {
                var words = sentence.Split(" ");

                foreach (var word in words)
                {
                    if (finalCopy.Count < count)
                    { 
                        finalCopy.Add(word.Trim());
                    }
                }
            }

            foreach(var value in finalCopy)
            {
                if (finalCopy.IndexOf(value) == 0)
                {
                    buildCopy.Append($"{value}");
                }
                else
                {
                    buildCopy.Append($" {value}");
                }
            }
            var result = buildCopy.ToString();
            var num = result.Split(" ").ToList();
            return result;
        }

    }
}
