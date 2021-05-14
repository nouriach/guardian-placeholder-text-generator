using System.Collections.Generic;
using System.Text;

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
                        finalCopy.Add(word);
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
            
            return buildCopy.ToString();
        }

    }
}