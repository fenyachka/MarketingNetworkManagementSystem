using Application.Core;
using Application.Products.DTO;
using Application.Products.Validators;
using AutoMapper;
using Domain.Entities.Products;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ProductDto ProductDto { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductDto).SetValidator(new ProductDtoValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var existingCheck = _unitOfWork.Product.TableNoTracking.FirstOrDefault(x => x.Code == request.ProductDto.Code);

                if (existingCheck != null)
                {
                    return Result<Unit>.Failure("Product  with such Code already exists.");
                }

                var product = _mapper.Map<ProductDto, Product>(request.ProductDto);

                _unitOfWork.Product.Add(product);

                var result = await _unitOfWork.SaveAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to create product");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
