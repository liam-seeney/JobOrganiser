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
            var currentJob = new JobInfo()
            {
                Id = 12,
                JobTitle = "Fix Door",
                JobDescription = "Replace hinges on bathroom door in bungalow."
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