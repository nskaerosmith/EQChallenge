using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pensions.Persistence.Entities.Maps
{
    public class AddressEntityMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> modelBuilder)
        {
            modelBuilder.HasKey(k => k.BasicId);
            modelBuilder.HasData(
                new Address
                {
                    BasicId = 1,
                    HouseName = "Sutherland House",
                    Street = "Russell Way",
                    Town = "Crawley",
                    County = "West Sussex",
                    Country = "United Kingdom",
                    PostCode = "RH10 1UH"
                },
                new Address
                {
                    BasicId = 2,
                    HouseName = "Sutherland House",
                    Street = "Russell Way",
                    Town = "Crawley",
                    County = "West Sussex",
                    Country = "United Kingdom",
                    PostCode = "RH10 1UH"
                },
                new Address
                {
                    BasicId = 3,
                    HouseName = "Sutherland House",
                    Street = "Russell Way",
                    Town = "Crawley",
                    County = "West Sussex",
                    Country = "United Kingdom",
                    PostCode = "RH10 1UH"
                },
                new Address
                {
                    BasicId = 4,
                    HouseName = "Sutherland House",
                    Street = "Russell Way",
                    Town = "Crawley",
                    County = "West Sussex",
                    Country = "United Kingdom",
                    PostCode = "RH10 1UH"
                }
            );
        }
    }
}
