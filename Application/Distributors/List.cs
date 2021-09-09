using Application.Core;
using Application.Distributors.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Distributors;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Distributors
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<DistributorToReturnDto>>>
        {
            public DistributorParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<DistributorToReturnDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
               _mapper = mapper;
            }

            public async Task<Result<PagedList<DistributorToReturnDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _unitOfWork.Distributor
                    .Include(x =>x.AddressInfo, y=>y.ContactInfo,z=>z.DocumentInfo)
                    .Where(x=>x.DateDeleted==null)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(request.Params.FirstName))
                {
                    query = query.Where(x => x.FirstName == request.Params.FirstName);
                }


                var data = await PagedList<Distributor>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize);

                var result = new PagedList<DistributorToReturnDto>(data.Select(_mapper.Map<Distributor, DistributorToReturnDto>), data.TotalCount, data.CurrentPage, data.PageSize);

                return Result<PagedList<DistributorToReturnDto>>.Success(result);
            }
        }
    }
}
