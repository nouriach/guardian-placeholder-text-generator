using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class ContentResultViewModel
    {
        public ContentResultViewModel()
        {

        }
        public ContentResultViewModel(string result)
        {
            Content = result;
        }
        public string Content { get; }
    }
}
