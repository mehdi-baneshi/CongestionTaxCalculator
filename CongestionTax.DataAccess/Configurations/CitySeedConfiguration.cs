using CongestionTax.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.DataAccess.Configurations
{
    internal class CitySeedConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City
                {
                    Id = 1,
                    Code = 1001,
                    Name = "Gothenburg"
                });
        }
    }
}
