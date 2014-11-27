using MyMortgage.Wpf.Core.Components.Main;
using MyMortgage.Wpf.Core.Components.Mortgage;

namespace MyMortgage.Wpf.Core.Components.Factory
{
    public interface IViewModelFactory
    {
        MainViewModel CreateMainViewModel(MainController controller);

        MortgagesViewModel CreateMortgagesViewModel(MortgagesController controller);

        MortgageViewModel CreateMortgageViewModel(MortgagesController controller);
    }
}
