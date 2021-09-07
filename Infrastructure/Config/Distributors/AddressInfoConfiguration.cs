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
    public class AddressInfoConfiguration : IEntityTypeConfiguration<AddressInfo>
    {
        public void Configure(EntityTypeBuilder<AddressInfo> builder)
        {
            builder.Property(p => p.AddressType).HasConversion<string>().IsRequired();
            builder.Property(p => p.AddressDetails).IsRequired().HasMaxLength(100);
        }
    }
}
