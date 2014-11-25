using System;
using System.Configuration;

using MyMortgage.Common.Validation;
using MyMortgage.RestApi.Common.Server;

namespace MyMortgage.RestApi.Runner
{
    public class ServiceRunnerFactory
    {
        private const string BaseUriKey = "BaseUri";
        private const string ServiceTypeKey = "ServiceType";

        public IServiceRunner CreateServiceRunner()
        {
            var baseUri = ConfigurationManager.AppSettings[BaseUriKey];
            var type = ServiceRunnerType.Parse(ConfigurationManager.AppSettings[ServiceTypeKey]);

            Ensure.That(Value.StringIsNotEmpty(baseUri), () => new InvalidOperationException("Invalid Uri configured"));
            Ensure.That(Value.IsNotNull(type), () => new InvalidOperationException("Invalid Service Runner type configured"));

            return type.CreateRunner(baseUri);
        }
    }
}
