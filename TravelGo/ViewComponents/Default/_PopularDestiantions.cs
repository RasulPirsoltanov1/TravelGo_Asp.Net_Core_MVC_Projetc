using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Default
{
    public class _PopularDestiantions : ViewComponent
    {
        DestinationManager _destinationManager = new DestinationManager(new DataAccessLayer.Concrete.EntityFramework.EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
    }
}
