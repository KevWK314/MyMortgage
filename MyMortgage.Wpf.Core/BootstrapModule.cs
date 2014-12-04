using MyMortgage.RestApi.Client;
using MyMortgage.RestApi.Common.Client;
using MyMortgage.Wpf.Core.Common.Context;
using MyMortgage.Wpf.Core.Common.Controllers;
using MyMortgage.Wpf.Core.Components.Factory;
using MyMortgage.Wpf.Core.Components.Main;
using MyMortgage.Wpf.Core.Components.Mortgage;
using MyMortgage.Wpf.Core.Config;

using Ninject;
using Ninject.Modules;

namespace MyMortgage.Wpf.Core
{
    public class BootstrapModule : NinjectModule
    {
        public override void Load()
        {
            // Controller
            Bind<MainController>().ToSelf().OnActivation(CreateController);
            Bind<MortgagesController>().ToSelf().OnActivation(CreateController); ;

            // ViewModel
            Bind<IViewModelFactory>().To<ViewModelFactory>();
            Bind<IUiContext>().To<UiContext>();

            // Service            
            Bind<IMyMortgageConfig>().To<MyMortgageConfig>();
            Bind<IRestClientService>().ToMethod(c => new RestClientService(c.Kernel.Get<IMyMortgageConfig>().BaseUri)).InSingletonScope();
            Bind<IMyMortgageClient>().To<MyMortgageClient>();
        }

        private void CreateController(IController controller)
        {
            controller.Create();
        }
    }
}
