using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using MyMortgage.Common.Validation;

namespace MyMortgage.RestApi.Common.Client
{
    public class RestClientService : IRestClientService
    {
        private readonly string _baseUri;

        public RestClientService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task<HttpWebResponse> SendRequest(string uri, RestMethod restMethod)
        {
            Ensure.That(Value.StringIsNotEmpty(uri), () => new ArgumentException("uri"));
            Ensure.That(Value.IsNotNull(restMethod), () => new ArgumentException("restMethod"));

            var webRequest = (HttpWebRequest)WebRequest.Create(GetActionUri(uri));
            webRequest.Method = restMethod.Method;

            return await webRequest.GetResponseAsync() as HttpWebResponse;
        }

        public async Task<HttpWebResponse> SendJsonRequest<TRequest>(string uri, RestMethod restMethod, TRequest request)
        {
            Ensure.That(Value.StringIsNotEmpty(uri), () => new ArgumentException("uri"));
            Ensure.That(Value.IsNotNull(restMethod), () => new ArgumentException("restMethod"));
            Ensure.That(Value.IsNotNull(request), () => new ArgumentException("request"));

            var serializer = new DataContractJsonSerializer(typeof(TRequest));
            var webRequest = (HttpWebRequest)WebRequest.Create(GetActionUri(uri));
            webRequest.ContentType = "application/json";
            webRequest.Method = restMethod.Method;
            serializer.WriteObject(webRequest.GetRequestStream(), request);

            return await webRequest.GetResponseAsync() as HttpWebResponse;
        }

        public TResult GetResponseResult<TResult>(HttpWebResponse response)
        {
            Ensure.That(Value.IsNotNull(response), () => new ArgumentException("response"));

            var serializer = new DataContractJsonSerializer(typeof(TResult));
            var res = serializer.ReadObject(response.GetResponseStream());
            var result = (TResult)res;

            return result;
        }

        private string GetActionUri(string uri)
        {
            return string.Format("{0}/{1}", _baseUri, uri);
        }
    }
}
