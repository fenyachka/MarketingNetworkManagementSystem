using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Distributors
{
    public class Photo : BaseEntity<int>
    {
        public string PictureUrl { get; set; }
        public string FileName { get; set; }
        public Distributor Distributor { get; set; }
        public Guid DistributorId { get; set; }
    }
}
