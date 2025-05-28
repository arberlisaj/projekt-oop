using System;
using System.Globalization;
using ArberLisaj.Calculator.Models;

namespace ArberLisaj.Calculator.Reports
{
    public class MortgageReport
    {
        private readonly MortgageCalculator calculator;

        public MortgageReport(MortgageCalculator calculator)
        {
            this.calculator = calculator;
        }

        public void PrintPaymentSchedule()
        {
            var usCulture = new CultureInfo("en-US");
            double[] balances = calculator.GetRemainingBalances();

            for (int i = 0; i < balances.Length; i++)
            {
                int muaji = i + 1;
                Console.WriteLine($"Month {muaji}: {balances[i].ToString("C", usCulture)} (Left to pay)");
            }
        }

        public void PrintMortgage()
        {
            var usCulture = new CultureInfo("en-US");
            double mortgage = calculator.CalculateMortgage();
            string mortgageFormatted = mortgage.ToString("C", usCulture);
            Console.WriteLine("Monthly payment: " + mortgageFormatted);
        }
    }
}