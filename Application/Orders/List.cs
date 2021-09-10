using Application.Core;
using Application.Orders.DTO;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<OrderDto>>>
        {
            public OrderParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<OrderDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<OrderDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _unitOfWork.Order
                    .Include(x => x.OrderItems)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(request.Params.DistributorId))
                {
                    query = query.Where(x => x.DistributorId == Guid.Parse(request.Params.DistributorId));
                }

                if (request.Params.OrderDate != null)
                {
                    query = query.Where(x => x.OrderDate == request.Params.OrderDate);
                }

                if (request.Params.ProductId!=null)
                {
                    query = query.Where(x => x.OrderItems.Any(x => x.ProductId == request.Params.ProductId));
                }


                var data = await PagedList<Order>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize);

                var result = new PagedList<OrderDto>(data.Select(_mapper.Map<Order, OrderDto>), data.TotalCount, data.CurrentPage, data.PageSize);

                return Result<PagedList<OrderDto>>.Success(result);
            }
        }
    }
}