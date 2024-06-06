using CongestionTax.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Domain.DbContext
{
    public interface ICongestionTaxDbContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<TimelyTollFee> TimelyTollFees { get; set; }
        DbSet<PublicHoliday> PublicHolidays { get; set; }
    }
}
