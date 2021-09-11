using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config.Bonus
{
    public class BonusConfiguration : IEntityTypeConfiguration<Domain.Entities.Bonuses.Bonus>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Bonuses.Bonus> builder)
        {
            builder.Property(p => p.BonusTotal).HasColumnType("decimal(18,2)");
        }
    }
}
