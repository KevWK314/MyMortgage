using MyMortgage.Wpf.Core.Common.Context;
using MyMortgage.Wpf.Core.Components.Main;
using MyMortgage.Wpf.Core.Components.Mortgage;

namespace MyMortgage.Wpf.Core.Components.Factory
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IUiContext _uiContext;

        public ViewModelFactory(IUiContext uiContext)
        {
            _uiContext = uiContext;
        }

        public MainViewModel CreateMainViewModel(MainController controller)
        {
            return new MainViewModel(controller, _uiContext);
        }

        public MortgagesViewModel CreateMortgagesViewModel(MortgagesController controller)
        {
            return new MortgagesViewModel(controller, _uiContext);
        }

        public MortgageViewModel CreateMortgageViewModel(MortgagesController controller)
        {
            return new MortgageViewModel(controller, _uiContext);
        }
    }
}
