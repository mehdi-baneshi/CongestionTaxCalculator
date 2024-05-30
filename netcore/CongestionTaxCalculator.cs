using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using congestion.calculator;
public class CongestionTaxCalculator
{
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    private const int MaxTaxValuePerDay = 60;
    private readonly IVehicle _vehicle;
    public CongestionTaxCalculator(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }


    public int GetTax(List<DateTime> dates)
    {
        if (_vehicle.IsExempt) return 0;

        var distincedLogsByDates = GetDistincedLogsByDates(dates);
        int totalFee = 0;

        foreach (var item in distincedLogsByDates)
        {
            if (IsTollFreeDate(item.Key)) continue;

            totalFee += CalculateDailyTax(item.Value);
        }

        return totalFee;
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

    private int CalculateDailyTax(List<TimeOnly> logs)
    {
        List<int> taxes = GetTaxesForEachLogApplyingHoursCongestionRule(logs);

        int totalTax = GetTaxApplyingSingleChargeRule(taxes, logs);

        return GetTaxApplyingMaxTaxPerDayRule(totalTax);
    }

    private List<int> GetTaxesForEachLogApplyingHoursCongestionRule(List<TimeOnly> oneDayLogs)
    {
        List<int> taxes = new List<int>();

        oneDayLogs.ForEach(l =>
        {
            taxes.Add(GetTollFee(l));
        });

        return taxes;
    }

    private int GetTaxApplyingSingleChargeRule(List<int> taxes, List<TimeOnly> logs)
    {
        logs = logs.OrderBy(l => l).ToList();
        int totalTax = 0;
        TimeOnly endRange = logs[0].AddHours(1);
        int appliableTax = taxes[0];

        for (int i = 1; i < logs.Count; i++)
        {
            if (logs[i] <= endRange)
            {
                appliableTax = Math.Max(taxes[i], appliableTax);
            }
            else
            {
                endRange = logs[i].AddHours(1);
                totalTax += appliableTax;
                appliableTax = taxes[i];
            }
        }

        totalTax += appliableTax;

        return totalTax;
    }

    private int GetTaxApplyingMaxTaxPerDayRule(int calculatedTax)
    {
        return Math.Min(calculatedTax, MaxTaxValuePerDay);
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

    private Boolean IsTollFreeDate(DateOnly date)
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