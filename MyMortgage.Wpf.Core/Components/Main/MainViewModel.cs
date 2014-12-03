using MyMortgage.Wpf.Core.Common.Context;
using MyMortgage.Wpf.Core.Common.ViewModel;
using MyMortgage.Wpf.Core.Components.Mortgage;

namespace MyMortgage.Wpf.Core.Components.Main
{
    public class MainViewModel : ViewModelBase
    {
        private readonly MainController _controller;

        public MortgagesViewModel MortgagesViewModel
        {
            get { return _controller.MortgagesViewModel; }
        }

        public MainViewModel(MainController controller, IUiContext uiContext)
            : base(uiContext)
        {
            _controller = controller;
        }
    }
}
