using System;
using System.Collections.Generic;
using System.Linq;
using survey.models;

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

        public List<Phone> PhoneTypes {
            get
            {
                var phones = new List<Phone>(){
                    new Phone(){ Id = 1, OS = "iOS" },
                    new Phone(){ Id = 2, OS = "Android" },
                    new Phone(){ Id = 3, OS = "Windows" }
                };

                return phones;
            }
        }
        
    }
}