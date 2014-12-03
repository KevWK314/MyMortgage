using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using MyMortgage.Common.Validation;

using Newtonsoft.Json;

namespace MyMortgage.RestApi.Common.Client
{
    public class RestClientService : IRestClientService
    {
        private readonly string _baseUri;
        private readonly JsonSerializer _serializer = new JsonSerializer();

        public RestClientService(string baseUri)
        {
            Ensure.That(Value.StringIsNotEmpty(baseUri), () => new ArgumentException("baseUri"));
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

            var webRequest = (HttpWebRequest)WebRequest.Create(GetActionUri(uri));
            webRequest.ContentType = "application/json";
            webRequest.Method = restMethod.Method;
            var stream = await webRequest.GetRequestStreamAsync();
            using(var sw = new StreamWriter(stream))
            {
                _serializer.Serialize(sw, request);
            }

            return await webRequest.GetResponseAsync() as HttpWebResponse;
        }

        public TResult GetResponseResult<TResult>(HttpWebResponse response)
        {
            Ensure.That(Value.IsNotNull(response), () => new ArgumentException("response"));

            var result = default(TResult);
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                using (var textReader = new JsonTextReader(sr))
                {
                    result = _serializer.Deserialize<TResult>(textReader);
                }
            }

            return result;
        }

        private string GetActionUri(string uri)
        {
            return string.Format("{0}/{1}", _baseUri, uri);
        }
    }
}
