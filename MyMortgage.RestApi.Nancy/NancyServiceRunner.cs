using System;
using MyMortgage.RestApi.Common.Server;
using Nancy.Hosting.Self;

namespace MyMortgage.RestApi.Nancy
{
    public class NancyServiceRunner : IServiceRunner
    {
        private readonly string _baseUri;
        private NancyHost _host;

        public NancyServiceRunner(string baseUri)
        {
            _baseUri = baseUri;
        }

        public void Start()
        {
            _host = new NancyHost(new Uri(_baseUri));
            _host.Start();
        }

        public void Stop()
        {
            if (_host != null)
            {
                _host.Stop();
            }
        }
    }
}
