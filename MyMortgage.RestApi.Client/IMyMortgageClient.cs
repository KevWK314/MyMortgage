using System.Threading.Tasks;
using MyMortgage.RestApi.Common.Dto;

namespace MyMortgage.RestApi.Client
{
    public interface IMyMortgageClient
    {
        Task<bool> IsServiceOkAsync();
        Task<double> GetMonthlyPaymentAsync(MonthlyPaymentsRequest req);
        Task<double> GetPrincipleRemainingAsync(PrincipleRemainingRequest req);
    }
}
