using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Domain.Entities
{
    public class PublicHoliday
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
    }
}
