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
    internal class PublicHolidaySeedConfiguration : IEntityTypeConfiguration<PublicHoliday>
    {
        public void Configure(EntityTypeBuilder<PublicHoliday> builder)
        {
            builder.HasData(
                new PublicHoliday
                {
                    Id =1,
                    Date= new DateOnly(2013,1,1)
                },
                new PublicHoliday
                {
                    Id = 2,
                    Date = new DateOnly(2013, 3, 29)
                },
                new PublicHoliday
                {
                    Id = 3,
                    Date = new DateOnly(2013, 4, 1)
                },
                new PublicHoliday
                {
                    Id = 4,
                    Date = new DateOnly(2013, 5, 1)
                },
                new PublicHoliday
                {
                    Id = 5,
                    Date = new DateOnly(2013, 5, 9)
                },
                new PublicHoliday
                {
                    Id = 6,
                    Date = new DateOnly(2013, 6, 6)
                },
                new PublicHoliday
                {
                    Id = 7,
                    Date = new DateOnly(2013, 6, 21)
                },
                new PublicHoliday
                {
                    Id = 8,
                    Date = new DateOnly(2013, 11, 1)
                },
                new PublicHoliday
                {
                    Id = 9,
                    Date = new DateOnly(2013, 12, 25)
                },
                new PublicHoliday
                {
                    Id = 10,
                    Date = new DateOnly(2013, 12, 26)
                });
        }
    }
}
