using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensions.Persistence.Entities.Maps
{
    public class ResultsEntityMap
    {
        public void Configure(EntityTypeBuilder<Results> modelBuilder)
        {
            modelBuilder.ToTable("Results");
            modelBuilder.HasKey(k => k.Id);
            
        }
    }
}
