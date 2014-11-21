using MyMortgage.RestApi.Client;
using MyMortgage.RestApi.Common.Client;
using MyMortgage.RestApi.Common.Dto;

namespace MyMortgage.RestApi.Specflow.Test.Context
{
    public class ClientContext
    {
        private readonly MyMortgageClient _client;

        public ClientContext()
        {
            _client = new MyMortgageClient(new RestClientService(ServiceContext.BaseUri));
        }

        public double GetMonthlyPayments(double principle, double rate, int durationInYears)
        {
            var req = new MonthlyPaymentsRequest
            {
                Principle = principle,
                Rate = rate,
                DurationInMonths = durationInYears * 12
            };
            return _client.GetMonthlyPaymentAsync(req).Result;
        }

        public double GetPrincipleRemaining(double principle, double rate, int durationInYears, int yearsAlreadyPaid, double monthlyPayment)
        {
            var req = new PrincipleRemainingRequest
            {
                Principle = principle,
                Rate = rate,
                DurationInMonths = durationInYears * 12,
                MonthsAlreadyPaid = yearsAlreadyPaid * 12,
                MonthlyPayment = monthlyPayment
            };
            return _client.GetPrincipleRemainingAsync(req).Result;
        }
    }
}
