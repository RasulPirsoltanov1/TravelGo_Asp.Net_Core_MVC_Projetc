using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemberLayout
{
    public class _MemberLayoutSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
