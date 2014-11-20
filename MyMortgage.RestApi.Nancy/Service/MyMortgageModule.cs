using System.Runtime.Serialization.Json;
using MyMortgage.Calculator;
using MyMortgage.RestApi.Common.Dto;
using Nancy;

namespace MyMortgage.RestApi.Nancy.Service
{
    public class MyMortgageModule : NancyModule
    {
        public MyMortgageModule()
        {
            Get["/status"] = p => GetStatus();

            Post["/monthlyPayment"] = p => Response.AsJson(GetMonthlyPayment(GetRequest<MonthlyPaymentsRequest>()));

            Post["/principleRemaining"] = p => Response.AsJson(GetPrincipleRemaining(GetRequest<PrincipleRemainingRequest>()));
        }

        public string GetStatus()
        {
            return "Nancy says hi";
        }

        private double GetMonthlyPayment(MonthlyPaymentsRequest request)
        {
            var result = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(request.Principle)
                .WithRate(request.Rate)
                .WithDurationInMonths(request.DurationInMonths)
                .Calculate();

            return result.MonthlyPayment;
        }

        private double GetPrincipleRemaining(PrincipleRemainingRequest request)
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

        private T GetRequest<T>()
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var res = (T)serializer.ReadObject(Request.Body);

            return res;
        }
    }
}
