using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Distributors
{
    public class AddressInfo : BaseEntity<int>
    {
        public AddressType AddressType { get; set; }
        public string AddressDetails { get; set; }
        public Distributor Distributor { get; set; }
        public Guid DistributorId { get; set; }
    }
}
