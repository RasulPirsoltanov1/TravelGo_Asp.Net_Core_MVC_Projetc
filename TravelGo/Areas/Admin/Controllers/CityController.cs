using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelGo.Models;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class CityController : Controller
    {
        IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        List<CityClass> cityClasses = new List<CityClass>()
        {
            new CityClass()
            {
                CityCountry="USA",
                CityId=1,
                CityName="NewYork"
            },
            new CityClass()
            {
                CityCountry="Russia",
                CityId=2,
                CityName="Moscova"
            },
            new CityClass()
            {
                CityCountry="China",
                CityId=3,
                CityName="Bangok"
            }
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var json = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(json);
        }
        [HttpPost]
        public IActionResult Add([FromBody]Destination destination)
        {
            _destinationService.TAdd(destination);  
            return Json(JsonConvert.SerializeObject(destination));
        }
        public IActionResult GetById([FromQuery]int DestinationId)
        {
            var json = JsonConvert.SerializeObject(_destinationService.TGetById(DestinationId));
            return Json(json);
        }

        public IActionResult Delete([FromQuery] int DestinationId)
        {
            var json = _destinationService.TGetById(DestinationId);
            _destinationService.TDelete(json);
            return Json("deleted");
        }
    }
}
