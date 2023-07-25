using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
