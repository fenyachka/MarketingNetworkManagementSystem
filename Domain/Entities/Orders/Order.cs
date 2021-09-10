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
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public decimal Total { get; set; }
    }
}
