using System.ServiceModel;
using System.ServiceModel.Web;
using MyMortgage.Calculator;
using MyMortgage.RestApi.Common.Dto;

namespace MyMortgage.RestApi.MsHttp.Service
{
    public class MyMortgageService : IMyMortgageService
    {
        public string GetStatus()
        {
            return "... And it's good!";
        }

        public double GetMonthlyPayment(MonthlyPaymentsRequest request)
        {            
            var result = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(request.Principle)
                .WithRate(request.Rate)
                .WithDurationInMonths(request.DurationInMonths)
                .Calculate();

            return result.MonthlyPayment;
        }

        public double GetPrincipleRemaining(PrincipleRemainingRequest request)
        {
            var result = Mortgage.HowMuchIsLeftToPay()
                .WithPrinciple(request.Principle)
                .WithRate(request.Rate)
                .WithDurationInMonths(request.DurationInMonths)
                .WithMonthsAlreadyPaid(request.MonthsAlreadyPaid)
                .WithMonthlyPaymentsOf(request.MonthlyPayment)                
                .Calculate();

            return result.PrincipleRemaining;
        }
    }
}
