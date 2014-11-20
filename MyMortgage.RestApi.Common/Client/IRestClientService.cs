using System.Net;
using System.Threading.Tasks;

namespace MyMortgage.RestApi.Common.Client
{
    public interface IRestClientService
    {
        Task<HttpWebResponse> SendRequest(string uri, RestMethod restMethod);

        Task<HttpWebResponse> SendJsonRequest<TRequest>(string uri, RestMethod restMethod, TRequest request);

        TResult GetResponseResult<TResult>(HttpWebResponse response);
    }
}
