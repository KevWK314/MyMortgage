using MyMortgage.RestApi.Common.Server;
using MyMortgage.RestApi.Nancy;

namespace MyMortgage.RestApi.Runner
{
    public class ServiceRunnerFactory
    {
        private readonly string _baseUri;

        public ServiceRunnerFactory(string baseUri)
        {
            _baseUri = baseUri;
        }

        public IServiceRunner CreateServiceRunner()
        {
            //return new MsHttpServiceRunner(_baseUri);
            return new NancyServiceRunner(_baseUri);
        }
    }
}
