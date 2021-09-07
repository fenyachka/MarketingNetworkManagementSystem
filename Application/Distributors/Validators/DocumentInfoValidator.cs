using Domain.Entities.Distributors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.Validators
{
    public class DocumentInfoValidator : AbstractValidator<DocumentInfo>
    {
        public DocumentInfoValidator()
        {
            RuleFor(p => p.DocumentType).NotNull().NotEmpty();
            RuleFor(p => p.Seria).MaximumLength(10);
            RuleFor(p => p.Number).MaximumLength(10);
            RuleFor(p => p.IssueDate).NotNull().NotEmpty();
            RuleFor(p => p.ExpirationDate).NotNull().NotEmpty();
            RuleFor(p => p.PrivateNumber).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.IssueOrganization).MaximumLength(100);
        }
    }
}
