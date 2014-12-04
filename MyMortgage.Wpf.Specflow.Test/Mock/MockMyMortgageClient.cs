using System;
using System.Threading.Tasks;

using MyMortgage.RestApi.Client;
using MyMortgage.RestApi.Common.Dto;

namespace MyMortgage.Wpf.Specflow.Test.Mock
{
    public class MockMyMortgageClient : IMyMortgageClient
    {
        public MockMyMortgageClient()
        {
            IsServiceOkResult = true;
        }

        public bool ThrowException
        {
            get;
            set;
        }

        public bool IsServiceOkResult
        {
            get;
            set;
        }

        public MonthlyPaymentsResponse MonthlyPaymentsResponse
        {
            get;
            set;
        }

        public PrincipleRemainingResponse PrincipleRemainingResponse
        {
            get;
            set;
        }

        public Task<bool> IsServiceOkAsync()
        {
            ThrowIfRequired();
            return Task.Run(() => IsServiceOkResult);
        }

        public Task<MonthlyPaymentsResponse> GetMonthlyPaymentAsync(MonthlyPaymentsRequest req)
        {
            ThrowIfRequired();
            return Task.Run(() => MonthlyPaymentsResponse);
        }

        public Task<PrincipleRemainingResponse> GetPrincipleRemainingAsync(PrincipleRemainingRequest req)
        {
            ThrowIfRequired();
            return Task.Run(() => PrincipleRemainingResponse);
        }

        private void ThrowIfRequired()
        {
            if (ThrowException)
            {
                throw new Exception("Server Failure");
            }
        }
    }
}
