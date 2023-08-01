using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.AdminDashboard
{
    public class _GuideListDashboard:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
