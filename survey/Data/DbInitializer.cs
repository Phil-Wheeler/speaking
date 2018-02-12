using System;
using System.Linq;
using System.Collections.Generic;
using survey.models;

namespace survey.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Phones.Any())
            {
                return;   // DB has been seeded
            }

            var phones = new List<Phone>(){
                new Phone(){ OS = "iOS" },
                new Phone(){ OS = "Android" },
                new Phone(){ OS = "Windows" }
            };
            foreach (Phone p in phones)
            {
                context.Phones.Add(p);
            }
            context.SaveChanges();

            var _socialNetworks = new List<SocialNetwork>()
            {
                new SocialNetwork(){ Name = "Facebook" },
                new SocialNetwork(){ Name = "Twitter" },
                new SocialNetwork(){ Name = "Instagram" },
                new SocialNetwork(){ Name = "Snapchat" },
                new SocialNetwork(){ Name = "Other" }
            };
            foreach(SocialNetwork sn in _socialNetworks)
            {
                context.SocialNetworks.Add(sn);
            }

            context.SaveChanges();

        }
    }
}