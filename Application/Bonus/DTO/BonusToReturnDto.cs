using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bonus.DTO
{
    public class BonusToReturnDto
    {
        public Guid DistributorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Period { get; set; }
        public decimal Bonus { get; set; }
    }
}
