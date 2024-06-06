using CongestionTax.Domain.Contracts.Rules;
using CongestionTax.Domain.Repositories;
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
        private const int GothenburgCityCode = 1001;
        private readonly IPublicHolidayRepository _publicHolidayRepository;
        private readonly ITimelyTollFeeRepository _timelyTollFeeRepository;

        public GothenburgCongestionTaxRule(IPublicHolidayRepository publicHolidayRepository, ITimelyTollFeeRepository timelyTollFeeRepository)
        {
            _publicHolidayRepository= publicHolidayRepository;
            _timelyTollFeeRepository= timelyTollFeeRepository;
        }

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
            return _timelyTollFeeRepository.GetTollFee(time, GothenburgCityCode);
        }

        public bool IsTollFreeDate(DateOnly date)
        {
            if (date.Month == 7) return true;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (date.Year==2013)
            {
                return _publicHolidayRepository.IsPublicHoliday(date) || _publicHolidayRepository.IsPublicHoliday(date.AddDays(1));
            }

            return false;
        }
    }
}
