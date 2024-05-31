using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using congestion.calculator;
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

    public int GetTax(List<DateTime> dates)
    {
        if (_vehicle.IsExempt) return 0;

        var distincedLogsByDates = GetDistincedLogsByDates(dates);
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

    private Dictionary<DateOnly, List<TimeOnly>> GetDistincedLogsByDates(List<DateTime> logs)
    {
        logs=logs.OrderBy(l => l).ToList();
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