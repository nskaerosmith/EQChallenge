using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pensions.Persistence.Entities;

namespace Pensions.Persistence.DbContexts
{
    public class PensionsContext : DbContext
    {
        public PensionsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Basic> Basic { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Salary> SalaryHistory { get; set; }
        public DbSet<Service> ServiceHistory { get; set; }
        public DbSet<Accrual> Accrual { get; set; }
        public DbSet<Results> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = Pensions; Trusted_Connection = True;"
            );

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
