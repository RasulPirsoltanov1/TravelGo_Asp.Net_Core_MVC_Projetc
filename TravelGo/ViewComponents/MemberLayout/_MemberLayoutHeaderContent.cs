using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemberLayout
{
    public class _MemberLayoutHeaderContent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
