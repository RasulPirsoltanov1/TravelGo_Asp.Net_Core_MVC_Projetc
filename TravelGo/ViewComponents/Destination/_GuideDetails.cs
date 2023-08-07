using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Destination
{
    public class _GuideDetails:ViewComponent
    {
        IGuideService _guideService;

        public _GuideDetails(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var count = _guideService.TGetList().Count();
            var guide = _guideService.TGetById(2);
            return View(guide);
        }
    }
}
