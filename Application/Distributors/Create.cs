using Application.Core;
using Application.Distributors.DTO;
using Application.Distributors.Validators;
using AutoMapper;
using Domain.Entities.Distributors;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Distributors
{
    public class Create
    {
        public class Command:IRequest<Result<Unit>>
        {
            public CreateDistributorDto CreateDistributorDto { get; set; }

        }
        public class CommandValidador : AbstractValidator<Command>
        {
            public CommandValidador()
            {
                RuleFor(x => x.CreateDistributorDto).SetValidator(new CreateDistributorDtoValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var distributor = _mapper.Map<CreateDistributorDto, Distributor>(request.CreateDistributorDto);

                _unitOfWork.Distributor.Add(distributor);

                var result = await _unitOfWork.SaveAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to create distributor");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
