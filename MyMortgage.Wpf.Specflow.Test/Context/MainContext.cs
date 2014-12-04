using MyMortgage.RestApi.Client;
using MyMortgage.Wpf.Core;
using MyMortgage.Wpf.Core.Components.Main;
using MyMortgage.Wpf.Core.Components.Mortgage;
using MyMortgage.Wpf.Specflow.Test.Mock;

using Ninject;

namespace MyMortgage.Wpf.Specflow.Test.Context
{
    public class MainContext
    {
        private bool initialised;
        private StandardKernel _kernel;
        private MainController _mainController;
        private readonly MockMyMortgageClient _client = new MockMyMortgageClient();

        public MainViewModel MainViewModel
        {
            get { return _mainController.ViewModel; }
        }

        public MortgagesViewModel MortgagesViewModel
        {
            get { return _mainController.MortgagesViewModel; }
        }

        public MockMyMortgageClient Client
        {
            get { return _client; }
        }

        public void Initialise()
        {
            if (!initialised)
            {
                initialised = true;

                _kernel = new StandardKernel(new BootstrapModule());
                _kernel.Rebind<IMyMortgageClient>().ToConstant(_client);

                _mainController = _kernel.Get<MainController>();
                _mainController.Create();
            }
        }
    }
}
