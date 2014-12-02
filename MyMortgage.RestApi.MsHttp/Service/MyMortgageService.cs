using MyMortgage.RestApi.Common.Dto;
using MyMortgage.RestApi.Common.Server;

namespace MyMortgage.RestApi.MsHttp.Service
{
    public class MyMortgageService : IMyMortgageService
    {
        private readonly MyMortgageCalcService _calc = new MyMortgageCalcService();

        public string GetStatus()
        {
            return "... and it's good!";
        }

        public MonthlyPaymentsResponse GetMonthlyPayment(MonthlyPaymentsRequest request)
        {            
            return _calc.GetMonthlyPayment(request);
        }

        public PrincipleRemainingResponse GetPrincipleRemaining(PrincipleRemainingRequest request)
        {
            return _calc.GetPrincipleRemaining(request);
        }
    }
}
