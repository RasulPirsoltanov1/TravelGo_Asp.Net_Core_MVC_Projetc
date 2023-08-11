using DTOLayer.DTOs.Password;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelGo.Models;

namespace TravelGo.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDTO forgetPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordDTO.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken,
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "travelgoazmail@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddress = new MailboxAddress("User", forgetPasswordDTO.Mail);
            mimeMessage.To.Add(mailboxAddress);
            mimeMessage.Subject = "Reset Password";
            mimeMessage.Body = new TextPart("plain")
            {
                Text = passwordResetTokenLink,
            };
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("travelgoazmail@gmail.com", "zokeisbytryyornc");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);



            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(int userId, string token)
        {
            TempData["token"] = token;
            TempData["userId"] = userId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];
            if (userId != null && token != null)
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordDTO.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }
    }
}
