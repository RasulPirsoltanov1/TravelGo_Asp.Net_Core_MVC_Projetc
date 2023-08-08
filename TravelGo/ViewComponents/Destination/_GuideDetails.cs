using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Destination
{
    public class _GuideDetails:ViewComponent
    {
        IGuideService _guideService;
        IDestinationService _destinationService;

        public _GuideDetails(IGuideService guideService, IDestinationService destinationService)
        {
            _guideService = guideService;
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var guide =_destinationService.GetDestinationWithGuide(d=>d.DestinationId==id);
            return View(guide);
        }
    }
}
