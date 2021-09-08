using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.DTO
{
    public class AddressInfoDto
    {

        public AddressType AddressType { get; set; }
        public string AddressDetails { get; set; }
    }
}
