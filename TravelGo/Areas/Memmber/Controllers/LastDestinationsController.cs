using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    [Route("[area]/[controller]/[action]")]
    public class LastDestinationsController : Controller
    {
        IDestinationService _destinationService;

        public LastDestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View(_destinationService.GetLastDestinations(4));
        }
    }
}
