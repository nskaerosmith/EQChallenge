using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pensions.Persistence.Entities.Maps
{
    public class AccrualEntityMap : IEntityTypeConfiguration<Accrual>
    {
        public void Configure(EntityTypeBuilder<Accrual> modelBuilder)
        {
            modelBuilder.ToTable("Accrual");
            modelBuilder.HasAlternateKey(k => k.EffectiveDate);
            modelBuilder.HasData(
                new Accrual { Id = 1, EffectiveDate = new DateTime(1950, 4, 6), Rate = 50 },
                new Accrual { Id = 2, EffectiveDate = new DateTime(2000, 4, 6), Rate = 80 },
                new Accrual { Id = 3, EffectiveDate = new DateTime(2015, 4, 6), Rate = 125 }
            );
        }
    }
}
