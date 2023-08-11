using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemberLayout
{
    [Authorize]
    public class _MemberLayoutProfileNavbar : ViewComponent
    {
        UserManager<AppUser> _userManager;

        public _MemberLayoutProfileNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User != null && User.Identity.Name != null)
            {
                return View(await _userManager.FindByNameAsync(User?.Identity?.Name));

            }
            return View(null);
        }
    }
}
