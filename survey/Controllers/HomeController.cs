using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using survey.Data;
using survey.models;
using survey.Models;
using System.Security.Claims;

namespace survey.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly List<Phone> _phones;
        private readonly List<SocialNetwork> _socialNetworks;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;

            _phones = new List<Phone>(){
                new Phone(){ Id = 1, OS = "iOS" },
                new Phone(){ Id = 2, OS = "Android" },
                new Phone(){ Id = 3, OS = "Windows" }
            };

            _socialNetworks = new List<SocialNetwork>()
            {
                new SocialNetwork(){ Id = 1, Name = "Facebook" },
                new SocialNetwork(){ Id = 2, Name = "Twitter" },
                new SocialNetwork(){ Id = 3, Name = "Instagram" },
                new SocialNetwork(){ Id = 4, Name = "Snapchat" },
                new SocialNetwork(){ Id = 5, Name = "Other" }
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Survey(string returnUrl)
        {
            ViewData["ReturnUrl"] = String.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
            var model = new SurveyViewModel(_context.Responses.AsEnumerable());

            return View(model);
        }

        [HttpPost]
        public IActionResult Survey(SurveyViewModel response)
        {
            var model = new Response();

            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.Respondent = Guid.Parse(user);

            model.Phone = _phones.SingleOrDefault(x => x.Id == response.Phone);
            model.SocialNetworks = _socialNetworks.Where(s => response.SocialNetworks.Any(sn => sn == s.Id)).ToList();

            _context.Responses.Add(model);
            _context.SaveChanges();
            
            return RedirectToAction("Survey");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
