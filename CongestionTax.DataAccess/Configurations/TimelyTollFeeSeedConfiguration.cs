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
    internal class TimelyTollFeeSeedConfiguration : IEntityTypeConfiguration<TimelyTollFee>
    {
        public void Configure(EntityTypeBuilder<TimelyTollFee> builder)
        {
            builder.HasData(
                new TimelyTollFee
                {
                    Id =1,
                    CityCode = 1001,
                    StartTime = new TimeOnly(0, 0),
                    EndTime = new TimeOnly(5, 59),
                    Fee = 0
                }, new TimelyTollFee
                {
                    Id = 2,
                    CityCode = 1001,
                    StartTime = new TimeOnly(6, 0),
                    EndTime = new TimeOnly(6, 29),
                    Fee = 8
                }, new TimelyTollFee
                {
                    Id = 3,
                    CityCode = 1001,
                    StartTime = new TimeOnly(6, 30),
                    EndTime = new TimeOnly(6, 59),
                    Fee = 13
                }, new TimelyTollFee
                {
                    Id = 4,
                    CityCode = 1001,
                    StartTime = new TimeOnly(7, 0),
                    EndTime = new TimeOnly(7, 59),
                    Fee = 18
                }, new TimelyTollFee
                {
                    Id = 5,
                    CityCode = 1001,
                    StartTime = new TimeOnly(8, 0),
                    EndTime = new TimeOnly(8, 29),
                    Fee = 13
                }, new TimelyTollFee
                {
                    Id = 6,
                    CityCode = 1001,
                    StartTime = new TimeOnly(8, 30),
                    EndTime = new TimeOnly(14, 59),
                    Fee = 8
                }, new TimelyTollFee
                {
                    Id = 7,
                    CityCode = 1001,
                    StartTime = new TimeOnly(15, 0),
                    EndTime = new TimeOnly(15, 29),
                    Fee = 13
                }, new TimelyTollFee
                {
                    Id = 8,
                    CityCode = 1001,
                    StartTime = new TimeOnly(15, 30),
                    EndTime = new TimeOnly(16, 59),
                    Fee = 18
                }, new TimelyTollFee
                {
                    Id = 9,
                    CityCode = 1001,
                    StartTime = new TimeOnly(17, 0),
                    EndTime = new TimeOnly(17, 59),
                    Fee = 13
                }, new TimelyTollFee
                {
                    Id = 10,
                    CityCode = 1001,
                    StartTime = new TimeOnly(18, 0),
                    EndTime = new TimeOnly(18, 29),
                    Fee = 8
                }, new TimelyTollFee
                {
                    Id = 11,
                    CityCode = 1001,
                    StartTime = new TimeOnly(18, 30),
                    EndTime = new TimeOnly(23, 59),
                    Fee = 0
                });
        }
    }
}
