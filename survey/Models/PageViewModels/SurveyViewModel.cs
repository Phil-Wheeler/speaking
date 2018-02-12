using System;
using System.Collections.Generic;
using System.Linq;
using survey.models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace survey.Models{

    public class SurveyViewModel
    {
        public SurveyViewModel()
        {}

        public SurveyViewModel(IEnumerable<Response> responses)
        {
            Responses = responses.ToList();
        }

        public List<Response> Responses {get; set;}

        public int Phone { get; set; }

        public int[] SocialNetworks { get; set; }

        public List<SelectListItem> Phones {
            get
            {
                var phones = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "iOS", Value = "1", Selected = true },
                    new SelectListItem(){ Text = "Android", Value = "2" },
                    new SelectListItem(){ Text = "Windows", Value = "3" }
                };

                return phones;
            }
        }

        public List<SelectListItem> Networks
        {
            get
            {
                var networks = new List<SelectListItem>(){
                    new SelectListItem(){ Value = "1", Text = "Facebook" },
                    new SelectListItem(){ Value = "2", Text = "Twitter" },
                    new SelectListItem(){ Value = "3", Text = "Instagram" },
                    new SelectListItem(){ Value = "4", Text = "Snapchat" },
                    new SelectListItem(){ Value = "5", Text = "Other" }
                };

                return networks;
            }
        }
        
    }
}