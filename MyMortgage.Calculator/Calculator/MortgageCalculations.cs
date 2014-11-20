using System;

namespace MyMortgage.Calculator.Calculator
{
    public static class MortgageCalculations
    {
        public static double CalculateMonthlyPayments(double principle, double rate, int durationInMonths)
        {
            var monthlyRate = CalculateMonthlyRate(rate);
            var term = CalculateTerm(monthlyRate, durationInMonths);

            return principle * ((monthlyRate * term) / (term - 1));
        }

        public static double CalculateRemaining(double principle, double rate, int months, int monthsCurrent, double monthlyPayments)
        {
            var monthlyRate = CalculateMonthlyRate(rate);
            var term = CalculateTerm(monthlyRate, months);
            var other = CalculateOtherTerm(monthlyRate, monthsCurrent);

            return principle * (term - other) / (term - 1);
        }

        private static double CalculateTerm(double monthlyRate, int durationInMonths)
        {
            return Math.Pow(1 + monthlyRate, durationInMonths);
        }

        private static double CalculateOtherTerm(double monthlyRate, double principle)
        {
            return Math.Pow(1 + monthlyRate, principle);
        }

        private static double CalculateMonthlyRate(double rate)
        {
            return rate / 100 / 12;
        }
    }
}
