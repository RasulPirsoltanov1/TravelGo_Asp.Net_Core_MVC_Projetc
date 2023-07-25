using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
