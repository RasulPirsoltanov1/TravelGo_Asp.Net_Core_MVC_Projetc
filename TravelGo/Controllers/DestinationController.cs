using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Controllers
{
    public class DestinationController : Controller
    {
        IDestinationService _destinationManager;

        public DestinationController(IDestinationService destinationManager)
        {
            _destinationManager = destinationManager;
        }

        public IActionResult Index()
        {
            return View(_destinationManager.TGetList());
        }
        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var value = _destinationManager.TGetById(id);
            ViewBag.Id = id;
            return View(value);
        }
        [HttpPost]
        public IActionResult DestinationDeatils(Destination destination)
        {
            return View();
        }
    }
}
