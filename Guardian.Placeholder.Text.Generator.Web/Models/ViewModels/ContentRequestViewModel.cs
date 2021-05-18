using Guardian.Text.Generator.Web.Application.Results.Authors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Guardian.Text.Generator.Web.Models.ViewModels
{
    public class ContentRequestViewModel
    {
        public ContentRequestViewModel(GetAuthorsResult authors)
        {
            Prompt = "Select an authour and a text request";
            Authors = authors.Authors;
        }
        [Display(Name = "Character Count Request")]
        public string CharacterCount { get; set;  }
        [Display(Name = "Word Count Request")]
        public string WordCount { get; set; }
        public string Prompt { get; set; }
        public List<string> Authors { get; set; }
    }
}
