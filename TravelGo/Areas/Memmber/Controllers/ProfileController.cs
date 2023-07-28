using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelGo.Areas.Memmber.Models;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    [Route("[area]/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationService _authenticationService;
        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (values != null)
                return View(new UserEditViewModel
                {
                    Email = values.Email,
                    UserName = values.UserName,
                    Name = values.Name,
                    Surname = values.Surname,
                    PhoneNumber = values.PhoneNumber,
                    ImageUrl = values.ImageUrl
                });

            else
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
                if (userEditViewModel.Image != null)
                {
                    var resurs = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(userEditViewModel.Image.FileName);
                    string imageName = Guid.NewGuid() + extension;
                    string directory = resurs + "/wwwroot/user_images/" + imageName;
                    using (var stream = System.IO.File.Create(directory))
                    {
                        await userEditViewModel.Image.CopyToAsync(stream);
                    }
                    user.ImageUrl = imageName;
                }
                user.Name = userEditViewModel.Name;
                user.Surname = userEditViewModel.Surname;
                user.UserName = userEditViewModel.UserName;
                user.PhoneNumber = userEditViewModel.PhoneNumber;
                user.Email = userEditViewModel.Email;
                if (userEditViewModel.Password != null)
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("SignIn", "Login");
                }
            }

            return View();
        }
    }
}
