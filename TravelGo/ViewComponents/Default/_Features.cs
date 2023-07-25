using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Default
{
    public class _Features:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FeatureManager _featureManager = new FeatureManager(new EfFeatureDal());
            var values = _featureManager.TGetList();
            return View(values);
        }
    }
}
