using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemmberDashboard
{
    public class _PlatformSettings:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
