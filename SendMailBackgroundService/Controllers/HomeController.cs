using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendMailBackgroundService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SendMailBackgroundService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InMemoryContext _context;
        public HomeController(ILogger<HomeController> logger,InMemoryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new List<UserMail>());
        }
        [HttpPost]
        public IActionResult Index(UserMail userMail)
        {
            if (ModelState.IsValid)
            {
                _context.UserMails.Add(userMail);
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Error = ModelState.FirstOrDefault().Value.Errors.FirstOrDefault().ErrorMessage;
                    
                return View(_context.UserMails.ToList());
            }
            return View(_context.UserMails.ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
