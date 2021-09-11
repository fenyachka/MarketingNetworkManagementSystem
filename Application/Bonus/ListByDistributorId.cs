using Application.Bonus.DTO;
using Application.Core;
using Application.Distributors.DTO;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Bonus
{
    public class ListByDistributorId
    {
        public class Query : IRequest<Result<List<BonusToReturnDto>>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<BonusToReturnDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<List<BonusToReturnDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = (from b in _unitOfWork.Bonus.TableNoTracking
                              join d in _unitOfWork.Distributor.TableNoTracking
                              on b.DistributorId equals d.Id
                              select new BonusToReturnDto
                              {
                                  DistributorId = b.DistributorId,
                                  FirstName = d.FirstName,
                                  LastName = d.LastName,
                                  Bonus = b.BonusTotal,
                                  Period = b.FromDate.ToString() + b.ToDate.ToString()
                              }).ToList();


                return Result<List<BonusToReturnDto>>.Success(result);
            }
        }
    }
}
