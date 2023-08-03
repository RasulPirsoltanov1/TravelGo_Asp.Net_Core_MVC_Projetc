using DocumentFormat.OpenXml.Wordprocessing;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelGo.Models;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Send(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "travelgoazmail@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddress = new MailboxAddress("User", mailRequest.MailReceiver);
            mimeMessage.To.Add(mailboxAddress);
            mimeMessage.Subject = mailRequest.Subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = mailRequest.Body
            };
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("travelgoazmail@gmail.com", "zokeisbytryyornc");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
