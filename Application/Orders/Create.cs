using Application.Core;
using Application.Orders.DTO;
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
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public OrderDto OrderDto { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var orderId = Guid.NewGuid();

                var list = _unitOfWork.Product.Table.Where(x => request.OrderDto.OrderItems.Select(y => y.ProductId).Contains(x.Id)).ToList();

                decimal totalPrice = 0;
                foreach (var item in request.OrderDto.OrderItems)
                {
                    totalPrice += item.Quantity * list.First(x => x.Id == item.ProductId).Price;

                }

                var order = new Order()
                {
                    Id = orderId,
                    DistributorId = request.OrderDto.DistributorId,
                    OrderDate = DateTime.Now,
                    Total = totalPrice
                };

                foreach (var item in request.OrderDto.OrderItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = orderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity

                    };

                    _unitOfWork.OrderItem.Add(orderItem);
                }

                _unitOfWork.Order.Add(order);

                var result = await _unitOfWork.SaveAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to create order");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
