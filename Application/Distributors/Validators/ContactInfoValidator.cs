using Domain.Entities.Distributors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.Validators
{
    public class ContactInfoValidator : AbstractValidator<ContactInfo>
    {
        public ContactInfoValidator()
        {
            RuleFor(p => p.ContactType).NotNull().NotEmpty();
            RuleFor(p => p.ContactDetails).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
