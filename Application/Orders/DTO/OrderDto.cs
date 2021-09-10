
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.DTO
{
    public class OrderDto
    {
        public Guid DistributorId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
