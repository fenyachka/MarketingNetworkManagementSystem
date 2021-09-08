using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.DTO
{
   public class ContactInfoDto
    {
        public ContactType ContactType { get; set; }
        public string ContactDetails { get; set; }
    }
}
