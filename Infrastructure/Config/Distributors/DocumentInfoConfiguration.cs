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
    public class DocumentInfoConfiguration : IEntityTypeConfiguration<DocumentInfo>
    {
        public void Configure(EntityTypeBuilder<DocumentInfo> builder)
        {
            builder.Property(p => p.DocumentType).HasConversion<string>().IsRequired();
            builder.Property(p => p.Seria).HasMaxLength(10);
            builder.Property(p => p.Number).HasMaxLength(10);
            builder.Property(p => p.IssueDate).IsRequired();
            builder.Property(p => p.ExpirationDate).IsRequired();
            builder.Property(p => p.PrivateNumber).IsRequired().HasMaxLength(50);
            builder.Property(p => p.IssueOrganization).HasMaxLength(100);
        }
    }
}
