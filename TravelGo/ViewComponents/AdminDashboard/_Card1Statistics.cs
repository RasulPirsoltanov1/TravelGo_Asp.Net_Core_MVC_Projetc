using DataAccessLayer.Concrete.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.AdminDashboard
{
    public class _Card1Statistics:ViewComponent
    {
        Context context=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Destinations.Count();
            ViewBag.v2 = context.Users.Count();
            return View();
        }
    }
}
