using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Domain.Repositories
{
    public interface IPublicHolidayRepository
    {
        bool IsPublicHoliday(DateOnly date);
    }
}
