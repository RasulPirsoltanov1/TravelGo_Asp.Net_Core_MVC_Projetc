using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    [Route("[Area]/[controller]/[action]")]
    public class DestinationController : Controller
    {
        private IDestinationService _destinationManager;

        public DestinationController(IDestinationService destinationManager)
        {
            _destinationManager = destinationManager;
        }

        public IActionResult Index()
        {
            List<Destination> destinationList = _destinationManager.TGetList();
            return View(destinationList);
        }
        [HttpGet]
        public IActionResult GetByName([FromQuery]string searchName)
        {
            ViewBag.Name = searchName;
            var dests = _destinationManager.TGetListByFilter(d => d.City.Contains(searchName));
            if (dests != null)
            {
                return View(dests);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
