using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class DestinationController : Controller
    {
        IDestinationService _destinationManager;

        public DestinationController(IDestinationService destinationManager)
        {
            _destinationManager = destinationManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationManager.TAdd(destination);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeleteDestinationById(int Id)
        {
            _destinationManager.TDelete(_destinationManager.TGetById(Id));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdateDestinationById(int Id)
        {
            var values = _destinationManager.TGetById(Id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestinationById(Destination destination)
        {
            _destinationManager.TUpdate(destination);
            return RedirectToAction(nameof(Index));
        }
    }
}
