using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
