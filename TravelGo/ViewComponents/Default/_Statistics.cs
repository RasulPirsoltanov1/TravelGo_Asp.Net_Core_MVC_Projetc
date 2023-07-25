using DataAccessLayer.Concrete.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                ViewBag.v1 = context.Destinations.Count();
                ViewBag.v2 = context.Guides.Count();
                ViewBag.v3 = context.NewsLetters.Count();
            }
            return View();
        }
    }
}
