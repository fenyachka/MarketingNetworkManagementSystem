using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.DTO
{
    public class CreateDistributorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public DocumentInfoDto DocumentInfo { get; set; }
        public ContactInfoDto ContactInfo { get; set; }
        public AddressInfoDto AddressInfo { get; set; }
    }
}
