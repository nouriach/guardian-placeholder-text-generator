using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class ContentRequestViewModel
    {
        public ContentRequestViewModel(string count)
        {
            CharacterCount = count;
        }

        public string CharacterCount { get; }
    }
}
