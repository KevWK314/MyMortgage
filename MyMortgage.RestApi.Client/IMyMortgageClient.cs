using System.Threading.Tasks;
using MyMortgage.RestApi.Common.Dto;

namespace MyMortgage.RestApi.Client
{
    public interface IMyMortgageClient
    {
        Task<bool> IsServiceOkAsync();
        Task<MonthlyPaymentsResponse> GetMonthlyPaymentAsync(MonthlyPaymentsRequest req);
        Task<PrincipleRemainingResponse> GetPrincipleRemainingAsync(PrincipleRemainingRequest req);
    }
}
