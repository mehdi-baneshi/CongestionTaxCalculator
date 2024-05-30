using System;
using System.Collections.Generic;
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


    public int GetTax(DateTime[] dates)
    {

        if (_vehicle.IsExempt) return 0;

        DateTime intervalStart = dates[0];
        int totalFee = 0;
        foreach (DateTime date in dates)
        {
            if (IsTollFreeDate(dates[0])) continue;
            int nextFee = GetTollFee(TimeOnly.FromDateTime(date));
            int tempFee = GetTollFee(TimeOnly.FromDateTime(intervalStart));

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies / 1000 / 60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    public int CalculateDailyTax(List<TimeOnly> logs)
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

    public int GetTollFee(TimeOnly time)
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

    private Boolean IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        return false;
    }

    private enum TollFreeVehicles
    {
        Motorcycle = 0,
        Tractor = 1,
        Emergency = 2,
        Diplomat = 3,
        Foreign = 4,
        Military = 5
    }
}