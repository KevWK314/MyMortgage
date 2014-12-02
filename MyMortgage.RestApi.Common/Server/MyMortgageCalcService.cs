using MyMortgage.Calculator;
using MyMortgage.RestApi.Common.Dto;

namespace MyMortgage.RestApi.Common.Server
{
    public class MyMortgageCalcService
    {
        public MonthlyPaymentsResponse GetMonthlyPayment(MonthlyPaymentsRequest request)
        {
            var result = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(request.Principle)
                .WithRate(request.Rate)
                .WithDurationInMonths(request.DurationInMonths)
                .Calculate();

            return new MonthlyPaymentsResponse
            {
                Principle = result.Principle,
                Rate = result.Rate,
                DurationInMonths = result.DurationInMonths,
                MonthlyPayment = result.MonthlyPayment,
                TotalPayments = result.TotalPayments
            };
        }

        public PrincipleRemainingResponse GetPrincipleRemaining(PrincipleRemainingRequest request)
        {
            var result = Mortgage.HowMuchIsLeftToPay()
                .WithPrinciple(request.Principle)
                .WithRate(request.Rate)
                .WithDurationInMonths(request.DurationInMonths)
                .WithMonthsAlreadyPaid(request.MonthsAlreadyPaid)
                .WithMonthlyPaymentsOf(request.MonthlyPayment)
                .Calculate();

            return new PrincipleRemainingResponse
            {
                Principle = result.Principle,
                PrincipleRemaining = result.PrincipleRemaining,
                Rate = result.Rate,
                DurationInMonths = result.DurationInMonths,
                MonthlyPayment = result.MonthlyPayment,
            };
        }
    }
}
