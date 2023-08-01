using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            return View(_appUserService.TGetList());
        }
        public IActionResult Delete(int id)
        {
            _appUserService.TDelete(_appUserService.TGetById(id));
            return View(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_appUserService.TGetById(id));
        }
        [HttpPost]
        public IActionResult Edit(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return View(nameof(Index));
        }
        [HttpGet]
        public IActionResult Comments(int id)
        {
            return View(_appUserService.TGetList());
        }
        [HttpGet]
        public IActionResult Reservations(int id)
        {
            return View(_appUserService.TGetList());
        }
    }
}
