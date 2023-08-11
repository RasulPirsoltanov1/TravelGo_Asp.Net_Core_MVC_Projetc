using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemberLayout
{
    public class _MemberLayoutSearch : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
