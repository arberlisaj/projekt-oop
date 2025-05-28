using ArberLisaj.Calculator.Helpers;
using ArberLisaj.Calculator.Models;
using ArberLisaj.Calculator.Reports;

namespace ArberLisaj.Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Po e bej ne Anglisht sepse kshu e kisha ber vjet ne Java dhe thjesht e perktheva :)
            int principal = (int)ConsoleHelper.LexoNumrin("Principal (Dollars): ", 1000, 1_000_000);
            float annualInterest = (float)ConsoleHelper.LexoNumrin("Annual Interest Rate (Percentage): ", 1, 30);
            byte years = (byte)ConsoleHelper.LexoNumrin("Period (Years): ", 1, 30);

            MortgageCalculator calculator = new MortgageCalculator(principal, annualInterest, years);
            MortgageReport report = new MortgageReport(calculator);

            report.PrintMortgage();
            report.PrintPaymentSchedule();
        }
    }
}