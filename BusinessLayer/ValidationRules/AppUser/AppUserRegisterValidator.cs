using DTOLayer.DTOs.AppUsrDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppUser
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(50);
            RuleFor(a => a.Username).NotEmpty().NotNull().MinimumLength(2).MaximumLength(50);
            RuleFor(a => a.Surname).NotEmpty().NotNull().MinimumLength(2).MaximumLength(50);
            RuleFor(a => a.PhoneNumber).NotEmpty().NotNull().MinimumLength(2).MaximumLength(50);
            RuleFor(a => a.Password).NotEmpty().NotNull().MinimumLength(8).MaximumLength(50).Must((a, av) => av == a.ConfirmPassword).WithMessage("password and confirmpassword does not match!");
            RuleFor(a => a.ConfirmPassword).NotEmpty().NotNull().MinimumLength(8).MaximumLength(50);
            RuleFor(a => a.Email).EmailAddress().NotEmpty().NotNull().MinimumLength(2).MaximumLength(50);
        }
    }
}
