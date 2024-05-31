using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.Domain.Contracts.Rules
{
    public interface ICityCongestionTaxRule
    {
        bool IsTollFreeDate(DateOnly date);
        List<int> GetTaxesForEachLogApplyingTollsFeeRule(List<TimeOnly> oneDayLogs);
        int GetTaxApplyingSingleChargeRule(List<int> taxes, List<TimeOnly> logs);
        int GetTaxApplyingMaxTaxPerDayRule(int calculatedTax);
    }
}
