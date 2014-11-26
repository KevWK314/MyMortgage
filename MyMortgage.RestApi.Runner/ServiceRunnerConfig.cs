using System.Configuration;

namespace MyMortgage.RestApi.Runner
{
    public class ServiceRunnerConfig
    {
        private const string BaseUriKey = "BaseUri";
        private const string ServiceTypeKey = "ServiceType";

        public string BaseUri
        {
            get;
            private set;
        }

        public string ServiceRunnerType
        {
            get;
            private set;
        }

        public ServiceRunnerConfig()
        {
            BaseUri = ConfigurationManager.AppSettings[BaseUriKey];
            ServiceRunnerType = ConfigurationManager.AppSettings[ServiceTypeKey];
        }
    }
}
