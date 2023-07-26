using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Comments
{
    public class _AddComment:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
