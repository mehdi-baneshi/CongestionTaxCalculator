using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CongestionTax.Calculator;
using CongestionTax.Domain.Contracts.Rules;
using CongestionTax.Domain.Contracts.Vehicle;
using CongestionTaxRules;
public class CongestionTaxCalculator
{
    private readonly IVehicle _vehicle;
    private readonly ICityCongestionTaxRule _cityCongestionTaxRule;

    public CongestionTaxCalculator(IVehicle vehicle, ICityCongestionTaxRule cityCongestionTaxRule)
    {
        _vehicle = vehicle;
        _cityCongestionTaxRule = cityCongestionTaxRule;
    }

    public int GetTotalTax(List<DateTime> dates)
    {
        if (_vehicle.IsExempt) return 0;

        var distincedLogsByDates = DateHelper.GetDistincedLogsByDates(dates);
        int totalFee = 0;

        foreach (var item in distincedLogsByDates)
        {
            if (_cityCongestionTaxRule.IsTollFreeDate(item.Key)) continue;

            totalFee += CalculateDailyTax(item.Value);
        }

        return totalFee;
    }

    private int CalculateDailyTax(List<TimeOnly> logs)
    {
        List<int> taxes = _cityCongestionTaxRule.GetTaxesForEachLogApplyingTollsFeeRule(logs);

        int totalTax = _cityCongestionTaxRule.GetTaxApplyingSingleChargeRule(taxes, logs);

        return _cityCongestionTaxRule.GetTaxApplyingMaxTaxPerDayRule(totalTax);
    }
}