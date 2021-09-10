using Application.Products.DTO;
using Domain.Entities.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Code).NotNull().NotEmpty();
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(p => p.Price).NotNull().NotEmpty();
        }
    }
}
