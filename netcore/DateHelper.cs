using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Calculator
{
    public static class DateHelper
    {
        public static Dictionary<DateOnly, List<TimeOnly>> GetDistincedLogsByDates(List<DateTime> logs)
        {
            logs = logs.OrderBy(l => l).ToList();
            var distincedLogsByDates = new Dictionary<DateOnly, List<TimeOnly>>();
            var oneDaylogs = new List<TimeOnly>();
            oneDaylogs.Add(TimeOnly.FromDateTime(logs[0]));

            for (int i = 1; i < logs.Count; i++)
            {
                if (logs[i].Date == logs[i - 1].Date)
                {
                    oneDaylogs.Add(TimeOnly.FromDateTime(logs[i]));
                }
                else
                {
                    distincedLogsByDates.Add(DateOnly.FromDateTime(logs[i - 1]), oneDaylogs);
                    oneDaylogs = new List<TimeOnly>();
                    oneDaylogs.Add(TimeOnly.FromDateTime(logs[i]));
                }
            }

            distincedLogsByDates.Add(DateOnly.FromDateTime(logs[logs.Count - 1]), oneDaylogs);

            return distincedLogsByDates;
        }
    }
}
