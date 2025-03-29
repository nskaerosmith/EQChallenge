using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pensions.Persistence.Entities.Maps
{
    public class BasicEntityMap : IEntityTypeConfiguration<Basic>
    {
        public void Configure(EntityTypeBuilder<Basic> modelBuilder)
        {
            modelBuilder.HasData(
                new Basic
                {
                    Id = 1,
                    Title = "Mr",
                    Forename = "Michael",
                    Surname = "Cole",
                    DateOfBirth = new DateTime(1969, 11, 12)
                },
                new Basic
                {
                    Id = 2,
                    Title = "Mrs",
                    Forename = "Elizabeth",
                    Surname = "Wright",
                    DateOfBirth = new DateTime(1981, 1, 31 )
                },
                new Basic
                {
                    Id = 3,
                    Title = "Mr",
                    Forename = "Daniel",
                    Surname = "Rose",
                    DateOfBirth = new DateTime(1993, 5, 7)
                }
                ,
                new Basic
                {
                    Id = 4,
                    Title = "Mrs",
                    Forename = "Pauline",
                    Surname = "Roberts",
                    DateOfBirth = new DateTime(1956, 12, 16)
                }
            );
        }
    }
}
