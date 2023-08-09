using BusinessLayer.Abstract;
using BusinessLayer.CQRS.Commands.ContactUsCommands;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        IContactUsService _contactUsService;
        IMediator _mediator;
        IValidator<ConatctUsCreateCommand> _validator;

        public ContactController(IContactUsService contactUsService, IMediator mediator, IValidator<ConatctUsCreateCommand> validator)
        {
            _contactUsService = contactUsService;
            _mediator = mediator;
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConatctUsCreateCommand conatctUsCreateCommand)
        {
            var result=await _validator.ValidateAsync(conatctUsCreateCommand);
            if (result.IsValid)
            {
                await _mediator.Send(conatctUsCreateCommand);
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
