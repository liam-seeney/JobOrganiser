using JobOrganiserWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobOrganiserWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var _name = new Customer()
            {
                FirstName = "John",
                LastName = "Smith"
            };

            var currentJob = new JobInfo()
            {
                Id = 12,
                JobTitle = "Fix Door",
                JobDescription = "Replace hinges on bathroom door in bungalow.",
                CustomerName = _name.FullName()
            };
            return View(currentJob);
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