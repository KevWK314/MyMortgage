using System;
using System.Configuration;

using MyMortgage.Common.Validation;
using MyMortgage.RestApi.Common.Server;

namespace MyMortgage.RestApi.Runner
{
    public class ServiceRunnerFactory
    {
        private ServiceRunnerConfig _config;

        public ServiceRunnerFactory(ServiceRunnerConfig config)
        {
            Ensure.That(Value.IsNotNull(config), () => new ArgumentNullException("config"));
            _config = config;
        }

        public IServiceRunner CreateServiceRunner()
        {
            var type = ServiceRunnerType.Parse(_config.ServiceRunnerType);
            Ensure.That(Value.IsNotNull(type), () => new InvalidOperationException("Invalid Service Runner type configured"));
            Ensure.That(Value.StringIsNotEmpty(_config.BaseUri), () => new InvalidOperationException("Invalid Uri configured"));

            return type.CreateRunner(_config.BaseUri);
        }
    }
}
