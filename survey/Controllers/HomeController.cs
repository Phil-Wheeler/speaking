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

            model.Phone = _context.Phones.SingleOrDefault(x => x.Id == response.Phone);
            model.SocialNetworks = _context.SocialNetworks.Where(s => response.SocialNetworks.Any(sn => sn == s.Id)).ToList();

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
