using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(a => a.Title).NotEmpty().WithMessage("Title can not be empty.");
            RuleFor(a => a.Image1).NotEmpty().WithMessage("Please select an image.");
            RuleFor(a => a.Description).MinimumLength(10).WithMessage("required description char count must bigger than 10.")
                .MaximumLength(1500).WithMessage("required description char count must less than 10.");
        }
    }
}
