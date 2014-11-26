using MyMortgage.RestApi.Common.Server;
using MyMortgage.RestApi.Runner;

namespace MyMortgage.RestApi.Specflow.Test.Context
{
    public class ServiceContext
    {
        private IServiceRunner _serviceRunner;

        public void StartService()
        {
            var factory = new ServiceRunnerFactory(new ServiceRunnerConfig());
            _serviceRunner = factory.CreateServiceRunner();

            _serviceRunner.Start();
        }

        public void StopService()
        {
            _serviceRunner.Stop();
        }
    }
}
