using MyMortgage.Wpf.Core.Common.ViewModel;
using MyMortgage.Wpf.Core.Components.Mortgage;

namespace MyMortgage.Wpf.Core.Components.Main
{
    public class MainViewModel
    {
        private readonly MainController _controller;

        private readonly ViewModelPropertyCollection _properties = new ViewModelPropertyCollection();

        public MortgagesViewModel MortgagesViewModel
        {
            get { return _controller.MortgagesViewModel; }
        }

        public MainViewModel(MainController controller)
        {
            _controller = controller;
        }
    }
}
