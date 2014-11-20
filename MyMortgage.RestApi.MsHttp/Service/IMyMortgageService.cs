using System.ServiceModel;
using System.ServiceModel.Web;
using MyMortgage.RestApi.Common.Dto;

namespace MyMortgage.RestApi.MsHttp.Service
{
    [ServiceContract]
    public interface IMyMortgageService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/status", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetStatus();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/monthlyPayment", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double GetMonthlyPayment(MonthlyPaymentsRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/principleRemaining", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double GetPrincipleRemaining(PrincipleRemainingRequest request);
    }
}
