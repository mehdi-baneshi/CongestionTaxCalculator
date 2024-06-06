using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Domain.Entities
{
    public class TimelyTollFee
    {
        public int Id { get; set; }
        public int CityCode { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int Fee { get; set; }
    }
}
