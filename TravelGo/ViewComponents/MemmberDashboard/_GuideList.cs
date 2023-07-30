using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.MemmberDashboard
{
    public class _GuideList : ViewComponent
    {
        GuideManager _guideManager = new GuideManager(new DataAccessLayer.Concrete.EntityFramework.EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var guides = _guideManager.TGetList();
            return View(guides);
        }
    }
}
