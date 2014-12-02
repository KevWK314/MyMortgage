using MyMortgage.RestApi.Common.Dto;
using MyMortgage.RestApi.Common.Server;

using Nancy;
using Nancy.ModelBinding;

namespace MyMortgage.RestApi.Nancy.Service
{
    public class MyMortgageModule : NancyModule
    {
        private MyMortgageCalcService _calc = new MyMortgageCalcService();

        public MyMortgageModule()
        {
            Get["/status"] = p => GetStatus();

            Post["/monthlyPayment"] = p => Response.AsJson(GetMonthlyPayment(this.Bind<MonthlyPaymentsRequest>()));

            Post["/principleRemaining"] = p => Response.AsJson(GetPrincipleRemaining(this.Bind<PrincipleRemainingRequest>()));
        }

        public string GetStatus()
        {
            return "Nancy says hi";
        }

        private MonthlyPaymentsResponse GetMonthlyPayment(MonthlyPaymentsRequest request)
        {
            return _calc.GetMonthlyPayment(request);
        }

        private PrincipleRemainingResponse GetPrincipleRemaining(PrincipleRemainingRequest request)
        {
            return _calc.GetPrincipleRemaining(request);
        }
    }
}
