using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
