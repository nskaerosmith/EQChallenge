using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pensions.Persistence.Entities.Maps
{
    public class ServiceEntityMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> modelBuilder)
        {
            modelBuilder.HasKey(k => new { k.BasicId, k.StartDate });
            modelBuilder.HasData(
                new Service { BasicId = 1, SchemeId = 1, StartDate = new DateTime(1990, 6,1) },
                new Service { BasicId = 2, SchemeId = 1, StartDate = new DateTime(2004, 12, 6), EndDate = new DateTime(2009, 1, 22) },
                new Service { BasicId = 2, SchemeId = 1, StartDate = new DateTime(2014, 3, 12) },
                new Service { BasicId = 3, SchemeId = 1, StartDate = new DateTime(2012, 6, 6), EndDate = new DateTime(2016,10,3) },
                new Service { BasicId = 4, SchemeId = 1, StartDate = new DateTime(1977, 2, 28), EndDate = new DateTime(1985, 7, 15) },
                new Service { BasicId = 4, SchemeId = 1, StartDate = new DateTime(1996, 5, 5), EndDate = new DateTime(2008, 9, 14) }
            );
        }
    }
}
