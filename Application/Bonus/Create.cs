using Application.Bonus.DTO;
using Application.Core;
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
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public DateParamsDto DateParamsDto { get; set; }
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
                var existingCheck = _unitOfWork.Bonus.TableNoTracking.FirstOrDefault(x => x.FromDate >= request.DateParamsDto.FromDate && x.ToDate <= request.DateParamsDto.ToDate);

                if (existingCheck == null)
                {
                    var totalBydistributorId = _unitOfWork.Order.TableNoTracking
                        .Where(x => x.OrderDate >= request.DateParamsDto.FromDate && x.OrderDate <= request.DateParamsDto.ToDate)
                        .GroupBy(x => x.DistributorId)
                        .Select(y => new
                        {
                            DistributorId = y.Key,
                            Total = y.Sum(z => z.Total)
                        }).ToList();

                    foreach (var item in totalBydistributorId)
                    {
                        var bonus = item.Total * (decimal)0.1;

                        var firstLevelReferals = _unitOfWork.Referals.TableNoTracking.Where(x => x.ReferalId == item.DistributorId).ToList();

                        if (firstLevelReferals.Count > 0)
                        {
                            foreach (var referal in firstLevelReferals)
                            {
                                bonus += totalBydistributorId.First(x => x.DistributorId == referal.DistributorId).Total * (decimal)0.05;

                                var secondLevelReferals = _unitOfWork.Referals.TableNoTracking.Where(x => x.ReferalId == referal.DistributorId).ToList();
                                if (secondLevelReferals.Count > 0)
                                {
                                    foreach (var referalSecondLevel in secondLevelReferals)
                                    {
                                        bonus += totalBydistributorId.First(x => x.DistributorId == referalSecondLevel.DistributorId).Total * (decimal)0.01;
                                    }
                                }
                            }
                        }

                        var distributorBonus = new Domain.Entities.Bonuses.Bonus()
                        {
                            FromDate = request.DateParamsDto.FromDate,
                            ToDate = request.DateParamsDto.ToDate,
                            DistributorId = item.DistributorId,
                            BonusTotal = bonus
                        };
                        _unitOfWork.Bonus.Add(distributorBonus);
                    }

                    var result = await _unitOfWork.SaveAsync(cancellationToken) > 0;
                    if (!result) return Result<Unit>.Failure("Failed to generate bonus");

                    return Result<Unit>.Success(Unit.Value);
                }
                else
                    return Result<Unit>.Failure("You have already calculated some days from this period. Please choose another period.");

            }
        }
    }
}

