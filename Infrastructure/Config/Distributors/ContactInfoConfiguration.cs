using Domain.Entities.Distributors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config.Distributors
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.Property(p => p.ContactType).HasConversion<string>().IsRequired();
            builder.Property(p => p.ContactDetails).IsRequired().HasMaxLength(100);
        }
    }
}
