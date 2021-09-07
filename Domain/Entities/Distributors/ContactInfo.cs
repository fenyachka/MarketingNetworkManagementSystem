using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Distributors
{
    public class ContactInfo : BaseEntity<int>
    {
        public ContactType ContactType { get; set; }
        public string ContactDetails { get; set; }
        public Distributor Distributor { get; set; }
        public Guid DistributorId { get; set; }
    }
}
