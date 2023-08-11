using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    [Route("[area]/[controller]/[action]")]
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
