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
    public class CreateDistributorDtoValidator : AbstractValidator<CreateDistributorDto>
    {
        public CreateDistributorDtoValidator()
        {
            RuleFor(p => p.FirstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p=>p.LastName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.BirthDate).NotNull().NotEmpty();
            RuleFor(p => p.Gender).NotNull().NotEmpty();
            RuleFor(p => p.DocumentInfo).SetValidator(new DocumentInfoDtoValidator());
            RuleFor(p => p.ContactInfo).SetValidator(new ContactInfoDtoValidator());
            RuleFor(p => p.AddressInfo).SetValidator(new AddressInfoDtoValidator());
        }
    }
}
