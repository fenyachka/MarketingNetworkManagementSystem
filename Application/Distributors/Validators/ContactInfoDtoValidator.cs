using Application.Distributors.DTO;
using Domain.Entities.Distributors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.Validators
{
    public class ContactInfoDtoValidator : AbstractValidator<ContactInfoDto>
    {
        public ContactInfoDtoValidator()
        {
            RuleFor(p => p.ContactType).NotNull().NotEmpty();
            RuleFor(p => p.ContactDetails).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
