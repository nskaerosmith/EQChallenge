using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pensions.Persistence.Entities.Maps
{
    public class SalaryEntityMap : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> modelBuilder)
        {
            modelBuilder.HasKey(k => new { k.BasicId, k.EffectiveDate });
            modelBuilder.HasData(
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1990, 6, 1), Value = 13760 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1991, 4, 6), Value = 14128.22 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1992, 4, 6), Value = 14506.29 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1993, 4, 6), Value = 14894.48 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1994, 4, 6), Value = 15293.06 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1995, 4, 6), Value = 15702.3 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1996, 4, 6), Value = 16122.49 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1997, 4, 6), Value = 16553.93 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1998, 4, 6), Value = 16996.91 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(1999, 4, 6), Value = 17451.75 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2000, 4, 6), Value = 17918.76 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2001, 4, 6), Value = 18398.27 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2002, 4, 6), Value = 18890.61 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2003, 4, 6), Value = 19396.12 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2004, 4, 6), Value = 19915.16 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2005, 4, 6), Value = 20448.09 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2006, 4, 6), Value = 20995.28 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2007, 4, 6), Value = 21557.11 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2008, 4, 6), Value = 22133.98 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2009, 4, 6), Value = 22726.29 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2010, 4, 6), Value = 23334.45 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2011, 4, 6), Value = 23958.88 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2012, 4, 6), Value = 24600.02 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2013, 4, 6), Value = 25258.32 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2014, 4, 6), Value = 25934.23 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2015, 4, 6), Value = 26628.23 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2016, 4, 6), Value = 27340.8 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2017, 4, 6), Value = 28072.44 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2018, 4, 6), Value = 28823.66 },
                new Salary { BasicId = 1, EffectiveDate = new DateTime(2019, 4, 6), Value = 29594.98 },
                new Salary { BasicId = 2, EffectiveDate = new DateTime(2004, 12, 6), Value = 23000 },
                new Salary { BasicId = 2, EffectiveDate = new DateTime(2014, 3, 12), Value = 26540 },
                new Salary { BasicId = 3, EffectiveDate = new DateTime(2012, 6, 6), Value = 100762.11 },
                new Salary { BasicId = 3, EffectiveDate = new DateTime(2013, 4, 6), Value = 90000.27 },
                new Salary { BasicId = 4, EffectiveDate = new DateTime(1977, 2, 28), Value = 15032.99 },
                new Salary { BasicId = 4, EffectiveDate = new DateTime(2007, 8, 12), Value = 33012.20 }
                );
        }
    }
}
