using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Domain.Repositories
{
    public interface ITimelyTollFeeRepository
    {
        int GetTollFee(TimeOnly time, int cityCode);
    }
}
