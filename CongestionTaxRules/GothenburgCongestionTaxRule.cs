using CongestionTax.Domain.Contracts.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxRules
{
    public class GothenburgCongestionTaxRule : ICityCongestionTaxRule
    {
        private const int MaxTaxValuePerDay = 60;
        private const int SingleChargeRulePeriodMins = 60;

        public int GetTaxApplyingMaxTaxPerDayRule(int calculatedTax)
        {
            return Math.Min(calculatedTax, MaxTaxValuePerDay);
        }

        public int GetTaxApplyingSingleChargeRule(List<int> taxes, List<TimeOnly> logs)
        {
            logs = logs.OrderBy(l => l).ToList();
            int totalTax = 0;
            TimeOnly endRange = logs[0].AddMinutes(SingleChargeRulePeriodMins);
            int appliableTax = taxes[0];

            for (int i = 1; i < logs.Count; i++)
            {
                if (logs[i] <= endRange)
                {
                    appliableTax = Math.Max(taxes[i], appliableTax);
                }
                else
                {
                    endRange = logs[i].AddMinutes(SingleChargeRulePeriodMins);
                    totalTax += appliableTax;
                    appliableTax = taxes[i];
                }
            }

            totalTax += appliableTax;

            return totalTax;
        }

        public List<int> GetTaxesForEachLogApplyingTollsFeeRule(List<TimeOnly> oneDayLogs)
        {
            List<int> taxes = new List<int>();

            oneDayLogs.ForEach(l =>
            {
                taxes.Add(GetTollFee(l));
            });

            return taxes;
        }

        private int GetTollFee(TimeOnly time)
        {
            int hour = time.Hour;
            int minute = time.Minute;

            if (hour == 6 && minute <= 29) return 8;
            else if (hour == 6 && minute >= 30) return 13;
            else if (hour == 7) return 18;
            else if (hour == 8 && minute <= 29) return 13;
            else if (hour == 8 && minute >= 30) return 8;
            else if (hour >= 9 && hour <= 14) return 8;
            else if (hour == 15 && minute <= 29) return 13;
            else if (hour == 15 && minute >= 30) return 18;
            else if (hour == 16) return 18;
            else if (hour == 17) return 13;
            else if (hour == 18 && minute <= 29) return 8;
            else return 0;
        }

        public bool IsTollFreeDate(DateOnly date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.Month == 7) return true;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29 || day == 31) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 20 || day == 21) ||
                    month == 10 && day == 31 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
