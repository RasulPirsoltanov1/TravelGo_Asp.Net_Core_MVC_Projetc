using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    [Route("[Area]/[Controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Username = $"{user.Name} {user.Surname}";
            ViewBag.ImageUrl = user.ImageUrl;
            return View();
        }
    }
}
