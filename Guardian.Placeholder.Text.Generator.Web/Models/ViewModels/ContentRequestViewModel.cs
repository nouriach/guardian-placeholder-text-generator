using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class ContentRequestViewModel
    {
        public ContentRequestViewModel()
        {
            Prompt = "Select an authour and a text request";
        }
        [Display(Name = "Character Count Request")]
        public string CharacterCount { get; set;  }
        [Display(Name = "Word Count Request")]
        public string WordCount { get; set; }
        public string Prompt { get; set; }

    }
}
