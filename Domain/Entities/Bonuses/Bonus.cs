using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bonuses
{
    public class Bonus : BaseEntity<int>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Guid DistributorId { get; set; }
        public decimal BonusTotal { get; set; }


    }
}
