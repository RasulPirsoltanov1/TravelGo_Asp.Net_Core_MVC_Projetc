using BusinessLayer.CQRS.Commands.ContactUsCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class ContactUsCreateCommandValidator:AbstractValidator<ConatctUsCreateCommand>
    {
        public ContactUsCreateCommandValidator()
        {
            RuleFor(c => c.Mail).NotEmpty().NotNull().EmailAddress();
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.MessageBody).NotEmpty().NotNull().MinimumLength(10).MaximumLength(1500);
            RuleFor(c => c.Subject).NotEmpty().NotNull().EmailAddress();
        }
    }
}
