using BusinessLayer.CQRS.Commands.GuideCommands;
using BusinessLayer.CQRS.Queries.GuideQueries;
using BusinessLayer.CQRS.Results.GuideResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class GuideMediatRController : Controller
    {
        private IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            GetAllGuidesQuery getAllGuidesQuery = new GetAllGuidesQuery();
            return View(await _mediator.Send(getAllGuidesQuery));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            GetByIdGuidesQuery getByIdGuidesQuery = new GetByIdGuidesQuery();
            getByIdGuidesQuery.Id = id;
            return View(await _mediator.Send(getByIdGuidesQuery));
        }
        [HttpPost]
        public async Task<IActionResult> Update(GetByIdGuideResult getByIdGuideResult)
        {
            UpdateGuideCommand updateGuideCommand = new UpdateGuideCommand();
            updateGuideCommand.Description = getByIdGuideResult.Description;
            updateGuideCommand.Image = getByIdGuideResult.Image;
            updateGuideCommand.Name = getByIdGuideResult.Name;
            updateGuideCommand.GuideId = getByIdGuideResult.GuideId;
            await _mediator.Send(updateGuideCommand);
            return RedirectToAction(nameof(Index));
        }
    }
}
