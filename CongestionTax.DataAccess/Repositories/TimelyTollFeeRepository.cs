using CongestionTax.Domain.DbContext;
using CongestionTax.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.DataAccess.Repositories
{
    public class TimelyTollFeeRepository : ITimelyTollFeeRepository
    {
        private readonly ICongestionTaxDbContext _dbContext;
        public TimelyTollFeeRepository(ICongestionTaxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetTollFee(TimeOnly time, int cityCode)
        {
            var fee=_dbContext.TimelyTollFees.FirstOrDefault(t =>t.CityCode==cityCode && t.StartTime <= time && t.EndTime >= time)?.Fee;

            return fee ?? 0;
        }
    }
}
