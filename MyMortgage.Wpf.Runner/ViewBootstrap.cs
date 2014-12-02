using MyMortgage.Wpf.Core;
using MyMortgage.Wpf.Core.Components.Main;

using Ninject;

namespace MyMortgage.Wpf.Runner
{
    public class ViewBootstrap
    {
        private readonly StandardKernel _kernel;

        private readonly MainController _mainController;

        private readonly MainView _mainView;

        public ViewBootstrap()
        {
            _kernel = new StandardKernel(new BootstrapModule());
            _mainController = _kernel.Get<MainController>();
            _mainController.Create();

            _mainView = new MainView { DataContext = this._mainController.ViewModel };
        }

        public MainView MainView
        {
            get { return _mainView; }
        }
    }
}
