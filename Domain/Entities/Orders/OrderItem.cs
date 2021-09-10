using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Orders
{
    public class OrderItem : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
