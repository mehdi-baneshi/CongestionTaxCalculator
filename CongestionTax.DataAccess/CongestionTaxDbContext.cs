using CongestionTax.DataAccess.Configurations;
using CongestionTax.Domain.DbContext;
using CongestionTax.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.DataAccess
{
    public class CongestionTaxDbContext:DbContext, ICongestionTaxDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=CongestionTax;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CitySeedConfiguration());
            modelBuilder.ApplyConfiguration(new PublicHolidaySeedConfiguration());
            modelBuilder.ApplyConfiguration(new TimelyTollFeeSeedConfiguration());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<TimelyTollFee> TimelyTollFees { get; set; }
        public DbSet<PublicHoliday> PublicHolidays { get; set; }
    }
}
