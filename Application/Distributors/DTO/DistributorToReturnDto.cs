using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.DTO
{
    public class DistributorToReturnDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string PictureUrl { get; set; }
        public string PrivateNumber { get; set; }
        public string ContactDetails { get; set; }
        public string AddressDetails { get; set; }
    }
}
