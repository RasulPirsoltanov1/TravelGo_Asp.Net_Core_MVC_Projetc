using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelGo.Models;

namespace TravelGo.Controllers
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
            _logger.LogInformation("Index page Invoke");
            _logger.LogError("Error Log Invoked");
            return View();
        }

        public IActionResult Privacy()
        {
            var d = DateTime.Now;
            _logger.LogInformation(d+ " Privacy page Invoke");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}