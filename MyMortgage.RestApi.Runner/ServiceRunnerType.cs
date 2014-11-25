using System;
using System.Linq;
using MyMortgage.RestApi.Common.Server;
using MyMortgage.RestApi.MsHttp;
using MyMortgage.RestApi.Nancy;

namespace MyMortgage.RestApi.Runner
{
    public class ServiceRunnerType
    {
        public static readonly ServiceRunnerType MsHttp = new ServiceRunnerType("MsHttp", uri => new MsHttpServiceRunner(uri));
        public static readonly ServiceRunnerType Nancy = new ServiceRunnerType("Nancy", uri => new NancyServiceRunner(uri));

        private readonly Func<string, IServiceRunner> _createRunner;

        public string Name
        {
            get;
            private set;
        }

        private ServiceRunnerType(string name, Func<string, IServiceRunner> createRunner)
        {
            Name = name;
            _createRunner = createRunner;
        }

        public static ServiceRunnerType Parse(string type)
        {
            return new[] { MsHttp, Nancy }
                .FirstOrDefault(t => t.Name.Equals(type, StringComparison.InvariantCultureIgnoreCase));
        }

        public IServiceRunner CreateRunner(string baseUri)
        {
            return _createRunner(baseUri);
        }
    }
}
