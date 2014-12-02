using System.Collections.ObjectModel;

using MyMortgage.Wpf.Core.Common.Commands;
using MyMortgage.Wpf.Core.Common.ViewModel;

namespace MyMortgage.Wpf.Core.Components.Mortgage
{
    using System.Windows.Input;

    public class MortgagesViewModel
    {
        private readonly MortgagesController _controller;
        private readonly ViewModelPropertyCollection _properties = new ViewModelPropertyCollection();

        public ObservableCollection<MortgageViewModel> Mortgages
        {
            get { return _controller.Children; }
        }

        public ViewModelCommand<DelegateCommand> AddCommand
        {
            get;
            private set;
        }

        public MortgagesViewModel(MortgagesController controller)
        {
            _controller = controller;

            CreateCommands();
            CreateProperties();
        }

        private void CreateCommands()
        {
            var addCommand = new DelegateCommand(() => _controller.AddNewMortgage());
            AddCommand = _properties.NewCommand("Add Mortgage", addCommand);
        }

        private void CreateProperties()
        {
        }
    }
}
