using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Orders
{
    public class Order:BaseEntity<Guid>
    {
        public Guid DistributorId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Total { get; set; }
    }
}
