using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    public class ReservationController : Controller
    {

        [HttpGet]
        public IActionResult MyCurrentReservation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MyOldReservation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {

            return View();
        }
    }
}
