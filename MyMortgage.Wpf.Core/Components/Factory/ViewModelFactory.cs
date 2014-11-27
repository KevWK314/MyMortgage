using MyMortgage.Wpf.Core.Components.Main;
using MyMortgage.Wpf.Core.Components.Mortgage;

namespace MyMortgage.Wpf.Core.Components.Factory
{
    public class ViewModelFactory : IViewModelFactory
    {
        public MainViewModel CreateMainViewModel(MainController controller)
        {
            return new MainViewModel(controller);
        }

        public MortgagesViewModel CreateMortgagesViewModel(MortgagesController controller)
        {
            return new MortgagesViewModel(controller);
        }

        public MortgageViewModel CreateMortgageViewModel(MortgagesController controller)
        {
            return new MortgageViewModel(controller);
        }
    }
}
