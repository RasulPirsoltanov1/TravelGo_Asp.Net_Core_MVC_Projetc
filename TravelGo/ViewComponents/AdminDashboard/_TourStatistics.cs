using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.AdminDashboard
{
    public class _TourStatistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
