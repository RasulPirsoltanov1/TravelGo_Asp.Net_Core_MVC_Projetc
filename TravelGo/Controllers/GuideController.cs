using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            return View(_guideService.TGetList());
        }
    }
}
