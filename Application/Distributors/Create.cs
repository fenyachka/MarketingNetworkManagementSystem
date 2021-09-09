using Application.Core;
using Application.Distributors.DTO;
using Application.Distributors.Validators;
using AutoMapper;
using Domain.Entities.Distributors;
using Domain.Entities.Mapping;
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
        public class Command : IRequest<Result<Unit>>
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
                var existingCheck = _unitOfWork.Distributor
                    .Include(x => x.DocumentInfo)
                    .Where(x => x.DocumentInfo.PrivateNumber == request.CreateDistributorDto.DocumentInfo.PrivateNumber)
                    .FirstOrDefault();

                if (existingCheck != null)
                {
                    if (existingCheck.DateDeleted!=null)
                    {
                        return Result<Unit>.Failure("Distributor with such Private Number was deleted from database.");
                    }
                    return Result<Unit>.Failure("Distributor with such Private Number already exists.");
                }

                var distributor = _mapper.Map<CreateDistributorDto, Distributor>(request.CreateDistributorDto);
                distributor.Id = Guid.NewGuid();

                if (string.IsNullOrWhiteSpace(request.CreateDistributorDto.ReferalId.ToString()))
                {
                    distributor.HierarchyLevel = 1;
                }
                else
                {
                    var parentId = Guid.Parse(request.CreateDistributorDto.ReferalId.ToString());

                    var referals = _unitOfWork.Referals.TableNoTracking.Where(x => x.DistributorId == parentId).ToList();

                    if (referals.Count < 3)
                    {
                        var parentLevel = _unitOfWork.Distributor.TableNoTracking.FirstOrDefault(x => x.Id == parentId).HierarchyLevel;
                        if (parentLevel < 5)
                        {
                            distributor.HierarchyLevel = ++parentLevel;

                            var refer = new Referals
                            {
                                DistributorId = Guid.Parse(request.CreateDistributorDto.ReferalId.ToString()),
                                ReferalId = distributor.Id
                            };

                            _unitOfWork.Referals.Add(refer);
                        }
                        else
                            return Result<Unit>.Failure("Distributor can't be registered.");
                    }
                    else
                        return Result<Unit>.Failure("Distributor can't be registered.");
                }

                _unitOfWork.Distributor.Add(distributor);

                var result = await _unitOfWork.SaveAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to create distributor");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
