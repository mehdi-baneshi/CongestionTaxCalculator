using CongestionTax.Domain.DbContext;
using CongestionTax.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.DataAccess.Repositories
{
    public class PublicHolidayRepository : IPublicHolidayRepository
    {
        private readonly ICongestionTaxDbContext _dbContext;
        public PublicHolidayRepository(ICongestionTaxDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public bool IsPublicHoliday(DateOnly date)
        {
            bool isPublicHoliday= _dbContext.PublicHolidays.Any(h => h.Date == date);
            return isPublicHoliday;
        }
    }
}
