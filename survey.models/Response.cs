using System;
using System.Collections.Generic;

namespace survey.models
{
    public class Response
    {
        public int Id { get; set; }
        public Guid Respondent { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual Phone Phone { get; set; }
        public virtual ICollection<SocialNetwork> SocialNetworks { get; set; }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string OS { get; set; }
    }

    public class SocialNetwork
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
