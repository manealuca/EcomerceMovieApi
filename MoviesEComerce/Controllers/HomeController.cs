using Microsoft.AspNetCore.Mvc;
using MoviesEComerce.Models;
using System.Diagnostics;

namespace MoviesEComerce.Controllers
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
            return View();
        }
    }
}