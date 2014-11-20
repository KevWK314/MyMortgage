using MyMortgage.Calculator.Builder;
using MyMortgage.Calculator.Model;

namespace MyMortgage.Calculator
{
    public static class MortgageExtensions
    {
        public static PrincipleRemainingBuilder HowMuchIsLeftToPay(this MonthlyPaymentResult monthlyPaymentResult)
        {
            return new PrincipleRemainingBuilder()
                .WithPrinciple(monthlyPaymentResult.Principle)
                .WithRate(monthlyPaymentResult.Rate)
                .WithDurationInMonths(monthlyPaymentResult.DurationInMonths)
                .WithMonthlyPaymentsOf(monthlyPaymentResult.MonthlyPayment)
                .WithYearsAlreadyPaid(1);
        }
    }
}
