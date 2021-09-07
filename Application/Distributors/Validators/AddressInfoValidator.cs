using Domain.Entities.Distributors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.Validators
{
    public class AddressInfoValidator : AbstractValidator<AddressInfo>
    {
        public AddressInfoValidator()
        {
            RuleFor(p => p.AddressType).NotNull().NotEmpty();
            RuleFor(p => p.AddressDetails).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
