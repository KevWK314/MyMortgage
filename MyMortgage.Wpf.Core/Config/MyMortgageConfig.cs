using System.Configuration;

namespace MyMortgage.Wpf.Core.Config
{
    public class MyMortgageConfig : IMyMortgageConfig
    {
        private const string BaseUriKey = "BaseUri";

        public string BaseUri { get; private set; }

        public MyMortgageConfig()
        {
            BaseUri = ConfigurationManager.AppSettings[BaseUriKey];
        }
    }
}
