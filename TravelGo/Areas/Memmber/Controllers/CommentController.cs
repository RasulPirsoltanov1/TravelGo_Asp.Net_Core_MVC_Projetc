using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Memmber.Controllers
{
    [Area("memmber")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
