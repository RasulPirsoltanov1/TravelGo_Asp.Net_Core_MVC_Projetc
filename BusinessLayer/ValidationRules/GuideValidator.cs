using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(g => g.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(50);
            RuleFor(g => g.Description).NotEmpty().NotNull().MinimumLength(2).MaximumLength(5000);
            RuleFor(g => g.Image).NotEmpty().MaximumLength(500);
        }
    }
}
