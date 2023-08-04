using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class ContactUsController : Controller
    {
        private IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        public IActionResult Index()
        {
            return View(_contactUsService.TGetList());
        }
        public IActionResult Delete(int id)
        {
            ContactUs mail = _contactUsService.TGetById(id);
            _contactUsService.TDelete(mail);
            return Json(JsonConvert.SerializeObject(mail));
        }
    }
}
