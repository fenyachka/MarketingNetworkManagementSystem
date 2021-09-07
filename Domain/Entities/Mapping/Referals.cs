using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Mapping
{
    public class Referals:BaseEntity<int>
    {
        public Guid DistributorId { get; set; }
        public Guid ReferalId { get; set; }
    }
}
