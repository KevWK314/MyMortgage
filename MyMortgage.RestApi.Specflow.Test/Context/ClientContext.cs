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
    }
}
