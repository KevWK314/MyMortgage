using System;
using System.Net;
using System.Threading.Tasks;
using MyMortgage.Common.Validation;
using MyMortgage.RestApi.Common.Client;
using MyMortgage.RestApi.Common.Dto;

namespace MyMortgage.RestApi.Client
{
    public class MyMortgageClient : IMyMortgageClient
    {
        private readonly IRestClientService _restClientService;

        public MyMortgageClient(IRestClientService restClientService)
        {
            _restClientService = restClientService;
        }

        public async Task<bool> IsServiceOkAsync()
        {
            var response = await _restClientService.SendRequest("status", RestMethod.Get);
            return response != null && response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<double> GetMonthlyPaymentAsync(MonthlyPaymentsRequest req)
        {
            Ensure.That(Value.IsNotNull(req), () => new ArgumentNullException("req"));

            var response = await _restClientService.SendJsonRequest("monthlyPayment", RestMethod.Post, req);
            var result = _restClientService.GetResponseResult<double>(response);
            return result;
        }

        public async Task<double> GetPrincipleRemainingAsync(PrincipleRemainingRequest req)
        {
            Ensure.That(Value.IsNotNull(req), () => new ArgumentNullException("req"));

            var response = await _restClientService.SendJsonRequest("principleRemaining", RestMethod.Post, req);
            var result = _restClientService.GetResponseResult<double>(response);
            return result;
        }
    }
}
