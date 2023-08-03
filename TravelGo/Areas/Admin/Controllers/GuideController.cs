using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
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
            GuideValidator validationRules = new GuideValidator();
            var validate=validationRules.Validate(guide);
            if (validate.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in validate.Errors)
                {
                    ModelState.AddModelError(item.ErrorCode,item.ErrorMessage);
                }
                return View();
            }

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
            Guide guide = _guideService.TGetById(id);
            if (guide.Status == true)
            {
                guide.Status = false; 
            }
            else
            {
                guide.Status = true;
            }
            _guideService.TUpdate(guide);
            return RedirectToAction(nameof(Index));
        }
    }
}
