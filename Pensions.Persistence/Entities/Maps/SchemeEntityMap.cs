using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pensions.Persistence.Entities.Maps
{
    public class SchemeEntityMap : IEntityTypeConfiguration<Scheme>
    {
        public void Configure(EntityTypeBuilder<Scheme> modelBuilder)
        {
            modelBuilder.HasData(
                new Scheme { Id = 1, Name = "Equiniti Scheme 1" }
            );
        }
    }
}
