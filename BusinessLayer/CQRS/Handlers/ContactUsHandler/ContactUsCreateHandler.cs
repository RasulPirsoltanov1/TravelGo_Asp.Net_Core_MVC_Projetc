using BusinessLayer.Abstract;
using BusinessLayer.CQRS.Commands.ContactUsCommands;
using BusinessLayer.CQRS.Results.ContactUsResults;
using DataAccessLayer.Concrete.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers.ContactUsHandler
{
    public class ContactUsCreateHandler : IRequestHandler<ConatctUsCreateCommand, ContactUsCreateResult>
    {
        IContactUsService _contactUsService;

        public ContactUsCreateHandler(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public async Task<ContactUsCreateResult> Handle(ConatctUsCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _contactUsService.TAdd(new EntityLayer.Concrete.ContactUs
                {
                    Mail = request.Mail,
                    MessageBody = request.MessageBody,
                    MessageDate = DateTime.Now,
                    MessageStatus = false,
                    Name = request.Name,
                    Subject = request.Subject,
                });
                var result = new ContactUsCreateResult();
                result.IsSuccess = true;
                return result;
            }
            catch (Exception)
            {
                var result = new ContactUsCreateResult();
                result.IsSuccess = false;
                return result;
            }

        }
    }
}
