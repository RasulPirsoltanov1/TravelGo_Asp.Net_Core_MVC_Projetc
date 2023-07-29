using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    [AllowAnonymous]
    [Route("[Area]/[controller]/[action]")]
    public class DestinationController : Controller
    {
        private DestinationManager _destinationManager = new DestinationManager(new DataAccessLayer.Concrete.EntityFramework.EfDestinationDal());
        public IActionResult Index()
        {
            List<Destination> destinationList = _destinationManager.TGetList();
            return View(destinationList);
        }
    }
}
