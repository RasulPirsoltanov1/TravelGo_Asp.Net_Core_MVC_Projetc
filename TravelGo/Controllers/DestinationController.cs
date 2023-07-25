using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new DataAccessLayer.Concrete.EntityFramework.EfDestinationDal());
        public IActionResult Index()
        {
            return View(_destinationManager.TGetList());
        }
        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var value = _destinationManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult DestinationDeatils(Destination destination)
        {
            return View();
        }
    }
}
