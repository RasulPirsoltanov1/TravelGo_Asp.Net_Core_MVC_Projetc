using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemberLayout
{
    public class _MemberLayoutLanguages: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
