using MyMortgage.Common.Task;
using MyMortgage.Wpf.Core.Common.Commands;
using MyMortgage.Wpf.Core.Common.Context;
using MyMortgage.Wpf.Core.Common.ViewModel;
using MyMortgage.Wpf.Core.Components.Mortgage;

namespace MyMortgage.Wpf.Core.Components.Main
{
    public class MainViewModel : ViewModelBase
    {
        private bool _refreshing;
        private readonly MainController _controller;

        public MortgagesViewModel MortgagesViewModel
        {
            get { return _controller.MortgagesViewModel; }
        }

        public MainViewModel(MainController controller, IUiContext uiContext)
            : base(uiContext)
        {
            _controller = controller;
            ValidateServer();
        }

        public ViewModelProperty<bool> IsServerAvailable
        {
            get;
            private set;
        }

        public ViewModelProperty<string> ServerError
        {
            get;
            private set;
        }

        public ViewModelCommand<DelegateCommand> RefreshCommand
        {
            get;
            private set;
        }

        protected override void CreateProperties()
        {
            IsServerAvailable = Properties
                .NewProperty<bool>("IsServerAvailable", () => false)
                .WithDescription("Server Status")
                .WhenUpdated(UpdateRefreshCommand)
                .WithVisibility(() => !IsServerAvailable.Value)
                .Build();
            ServerError = Properties
                .NewProperty<string>("ServerError", () => string.Empty)
                .WithVisibility(() => !string.IsNullOrEmpty(ServerError.Value))
                .WhenUpdated(UpdateRefreshCommand)
                .Build();
        }

        protected override void CreateCommands()
        {
            RefreshCommand = Properties.NewCommand("Refresh", new DelegateCommand(ValidateServer, () => !_refreshing));
        }

        private void UpdateRefreshCommand()
        {
            UiContext.BeginInvoke(RefreshCommand.Command.UpdateCanExecute);
        }

        private void ValidateServer()
        {
            _refreshing = true;
            UpdateRefreshCommand();

            _controller.IsServerAvailable().ContinueWith(
                r =>
                {
                    IsServerAvailable.Value = r;
                    ServerError.Value = string.Empty;
                },
                e =>
                {
                    IsServerAvailable.Value = false;
                    ServerError.Value = "Unable to connect to the server";
                },
                () =>
                {
                    _refreshing = false;
                    UpdateRefreshCommand();
                });
        }
    }
}
