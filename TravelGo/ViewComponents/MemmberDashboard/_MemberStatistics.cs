using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemmberDashboard
{
    public class _MemberStatistics:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberStatistics(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NameSurname = $"{user.Name} {user.Surname}";
            ViewBag.phone = user.PhoneNumber;
            ViewBag.email = user.Email;
            return View();
        }
    }
}
