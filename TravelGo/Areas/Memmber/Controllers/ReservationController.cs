using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    [Route("[Area]/[controller]/[action]")]

    public class ReservationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager _reservationManager = new ReservationManager(new EfReservationDal());
        UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> MyCurrentReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var reservations = _reservationManager.GetAllReservationsWithDestination(r => r.AppUserId == user.Id && r.Status == "accepted");
            return View(reservations);
        }
        [HttpGet]
        public async Task<IActionResult> MyOldReservationAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = user.Id;
            var reservations = _reservationManager.GetAllReservationsWithDestination(r => r.AppUserId == user.Id && (r.Status == "finished" || r.Status == "denied" || r.Status == "rejected"));
            return View(reservations);
        }
        [HttpGet]
        public async Task<IActionResult> MyAppRovalReservationAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = user.Id;
            var reservations = _reservationManager.GetAllReservationsWithDestination(r => r.AppUserId == user.Id && r.Status == "wait verifying");
            return View(reservations);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            reservation.AppUserId = 7;
            reservation.Status = "wait verifying";
            reservation.DestinationId = 2;
            _reservationManager.TAdd(reservation);
            return RedirectToAction(nameof(MyCurrentReservation));
        }
    }
}
