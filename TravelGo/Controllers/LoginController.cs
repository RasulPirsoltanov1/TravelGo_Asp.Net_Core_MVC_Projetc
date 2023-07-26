using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelGo.Models;

namespace TravelGo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = registerViewModel.Name,
                    UserName = registerViewModel.Username,
                    Surname = registerViewModel.Surname,
                    Email = registerViewModel.Email
                };
                if (registerViewModel.Password == registerViewModel.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }

            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
