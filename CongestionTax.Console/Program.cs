// See https://aka.ms/new-console-template for more information
using CongestionTax.Domain.Contracts.Rules;
using CongestionTax.Domain.Contracts.Vehicle;
using CongestionTax.Domain.Models.Vehicle;
using CongestionTaxRules;

Console.WriteLine("Calculating total congestion tax:");

IVehicle car = new Car();
ICityCongestionTaxRule gothenburg = new GothenburgCongestionTaxRule();

List<DateTime> logs = new List<DateTime>();
logs.Add(new DateTime(2013, 1, 14, 21, 10, 0));
logs.Add(new DateTime(2013, 1, 15, 21, 10, 0));
logs.Add(new DateTime(2013, 2, 7, 6, 23, 27));
logs.Add(new DateTime(2013, 2, 7, 15, 27, 0));
logs.Add(new DateTime(2013, 2, 8, 6, 27, 0));
logs.Add(new DateTime(2013, 2, 8, 6, 20, 27));
logs.Add(new DateTime(2013, 2, 8, 14, 35, 0));
logs.Add(new DateTime(2013, 2, 8, 15, 29, 0));
logs.Add(new DateTime(2013, 2, 8, 15, 47, 0));
logs.Add(new DateTime(2013, 2, 8, 16, 1, 0));
logs.Add(new DateTime(2013, 2, 8, 16, 48, 0));
logs.Add(new DateTime(2013, 2, 8, 17, 49, 0));
logs.Add(new DateTime(2013, 2, 8, 18, 29, 0));
logs.Add(new DateTime(2013, 2, 8, 18, 35, 0));
logs.Add(new DateTime(2013, 3, 26, 14, 25, 0));
logs.Add(new DateTime(2013, 3, 28, 14, 7, 27));

var taxCalculator = new CongestionTaxCalculator(car, gothenburg);

var totalTax = taxCalculator.GetTotalTax(logs);

Console.WriteLine(totalTax);
