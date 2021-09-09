using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Distributors
{
    public class Distributor : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public Photo Photo { get; set; }
        public DocumentInfo DocumentInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public AddressInfo AddressInfo { get; set; }
        public int HierarchyLevel { get; set; }
        public DateTime? DateDeleted { get; set; }

    }
}
