using System;

namespace ArberLisaj.Calculator.Models
{
    public class MortgageCalculator
    {
        private const byte MUJTE_NE_VIT = 12;
        private const byte PERCENT = 100;

        private readonly int principal;
        private readonly float annualInterest;
        private readonly byte years;

        public MortgageCalculator(int principal, float annualInterest, byte years)
        {
            this.principal = principal;
            this.annualInterest = annualInterest;
            this.years = years;
        }

        public double CalculateBalance(short numberOfPaymentsMade)
        {
            float monthlyInterest = GetMonthlyInterest();
            float numberOfPayments = GetNumberOfPayments();

            return principal
                * (Math.Pow(1 + monthlyInterest, numberOfPayments)
                   - Math.Pow(1 + monthlyInterest, numberOfPaymentsMade))
                / (Math.Pow(1 + monthlyInterest, numberOfPayments) - 1);
        }

        public double CalculateMortgage()
        {
            float monthlyInterest = GetMonthlyInterest();
            float numberOfPayments = GetNumberOfPayments();

            return principal
                * (monthlyInterest * Math.Pow(1 + monthlyInterest, numberOfPayments))
                / (Math.Pow(1 + monthlyInterest, numberOfPayments) - 1);
        }

        public double[] GetRemainingBalances()
        {
            int totalPayments = GetNumberOfPayments();
            double[] balances = new double[totalPayments];
            for (short month = 1; month <= totalPayments; month++)
            {
                balances[month - 1] = CalculateBalance(month);
            }
            return balances;
        }

        private float GetMonthlyInterest()
        {
            return annualInterest / PERCENT / MUJTE_NE_VIT;
        }

        private int GetNumberOfPayments()
        {
            return years * MUJTE_NE_VIT;
        }
    }
}