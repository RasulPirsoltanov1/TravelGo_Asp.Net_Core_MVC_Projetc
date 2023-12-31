﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemmberDashboard
{
    public class _ProfileInformation : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NameSurname = $"{user.Name} {user.Surname}";
            ViewBag.phone = user.PhoneNumber;
            ViewBag.email = user.Email;
            ViewBag.image = user.ImageUrl;
            return View();
        }
    }
}
