using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
