using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Default
{
    public class _PopularDestiantions : ViewComponent
    {
       IDestinationService _destinationManager ;

        public _PopularDestiantions(IDestinationService destinationManager)
        {
            _destinationManager = destinationManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
    }
}
