using BusinessLayer.CQRS.Handlers.DestinationHandlers;
using BusinessLayer.CQRS.Queries.Destinations;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class DestinationCQRSController : Controller
    {
        private GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private GetByIdDestinationQueryHandler _getByIdDestinationQueryHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetByIdDestinationQueryHandler getByIdDestinationQueryHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getByIdDestinationQueryHandler = getByIdDestinationQueryHandler;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _getAllDestinationQueryHandler.Handler());
        }
        public async Task<IActionResult> Update([FromQuery]int id)
        {
            GetByIdDestinationQuery getByIdDestinationQuery = new GetByIdDestinationQuery();
            getByIdDestinationQuery.Id = id;
            return View(await _getByIdDestinationQueryHandler.Handler(getByIdDestinationQuery));
        }
    }
}
