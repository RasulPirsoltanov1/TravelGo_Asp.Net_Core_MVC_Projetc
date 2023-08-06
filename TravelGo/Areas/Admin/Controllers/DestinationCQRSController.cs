using BusinessLayer.CQRS.Commands.DestinationCommands;
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
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly DeleteDestinationCommandHandler _deleteDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetByIdDestinationQueryHandler getByIdDestinationQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, DeleteDestinationCommandHandler deleteDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getByIdDestinationQueryHandler = getByIdDestinationQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _deleteDestinationCommandHandler = deleteDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _getAllDestinationQueryHandler.Handler());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateDestinationCommand createDestinationCommand)
        {
            await _createDestinationCommandHandler.Handle(createDestinationCommand);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            RemoveDestinationCommand removeDestinationCommand = new RemoveDestinationCommand();
            removeDestinationCommand.Id = id;
            _deleteDestinationCommandHandler.Handle(removeDestinationCommand);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update([FromQuery] int id)
        {
            GetByIdDestinationQuery getByIdDestinationQuery = new GetByIdDestinationQuery();
            getByIdDestinationQuery.Id = id;
            return View(await _getByIdDestinationQueryHandler.Handler(getByIdDestinationQuery));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDestinationCommand updateDestinationCommand)
        {
            await _updateDestinationCommandHandler.Handle(updateDestinationCommand);
            return RedirectToAction(nameof(Index));
        }
    }
}
