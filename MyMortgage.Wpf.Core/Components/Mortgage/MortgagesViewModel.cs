using System.Collections.ObjectModel;

using MyMortgage.Wpf.Core.Common.Context;
using MyMortgage.Wpf.Core.Common.Commands;
using MyMortgage.Wpf.Core.Common.ViewModel;

namespace MyMortgage.Wpf.Core.Components.Mortgage
{
    public class MortgagesViewModel : ViewModelBase
    {
        private readonly MortgagesController _controller;

        public ObservableCollection<MortgageViewModel> Mortgages
        {
            get { return _controller.Children; }
        }

        public MortgagesViewModel(MortgagesController controller, IUiContext uiContext)
            : base(uiContext)
        {
            _controller = controller;
        }

        public ViewModelCommand<DelegateCommand> AddCommand
        {
            get;
            private set;
        }

        protected override void CreateCommands()
        {
            var addCommand = new DelegateCommand(() => _controller.AddNewMortgage());
            AddCommand = Properties.NewCommand("Add Mortgage", addCommand);
        }
    }
}
