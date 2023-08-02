using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            return View(_guideService.TGetList());
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            _guideService.TAdd(guide);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            return View(_guideService.TGetById(id));
        }

        [HttpPost]
        public IActionResult UpdateGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
