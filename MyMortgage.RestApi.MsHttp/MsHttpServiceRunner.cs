using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using MyMortgage.RestApi.Common.Server;
using MyMortgage.RestApi.MsHttp.Service;

namespace MyMortgage.RestApi.MsHttp
{
    public class MsHttpServiceRunner : IServiceRunner
    {
        public WebServiceHost _host;
        public readonly string _baseUri;

        public string Name
        {
            get { return "MsHttp"; }
        }

        public MsHttpServiceRunner(string baseUri)
        {
            _baseUri = baseUri;
        }

        public void Start()
        {
            _host = new WebServiceHost(typeof(MyMortgageService), new Uri(_baseUri));
            try
            {
                _host.AddServiceEndpoint(typeof(IMyMortgageService), new WebHttpBinding(), string.Empty);

                var smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
                _host.Description.Behaviors.Add(smb);

                _host.Open();
            }
            catch (CommunicationException)
            {
                _host.Abort();
                throw;
            }
        }

        public void Stop()
        {
            if (_host != null)
            {
                _host.Close();
            }
        }
    }
}
