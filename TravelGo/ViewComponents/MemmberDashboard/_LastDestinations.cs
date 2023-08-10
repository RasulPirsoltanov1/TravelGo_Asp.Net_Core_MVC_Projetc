using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemmberDashboard
{
    public class _LastDestinations:ViewComponent
    {
        IDestinationService _destinationService;

        public _LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_destinationService.GetLastDestinations(4));
        }
    }
}
