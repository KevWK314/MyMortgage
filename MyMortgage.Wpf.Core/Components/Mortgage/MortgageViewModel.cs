using MyMortgage.Common.Task;
using MyMortgage.Wpf.Core.Common.Context;
using MyMortgage.Wpf.Core.Common.Commands;
using MyMortgage.Wpf.Core.Common.ViewModel;

namespace MyMortgage.Wpf.Core.Components.Mortgage
{
    public class MortgageViewModel : ViewModelBase
    {
        private MortgageModel _model = new MortgageModel();
        private readonly MortgagesController _controller;

        public MortgageViewModel(MortgagesController controller, IUiContext uiContext)
            : base(uiContext)
        {
            _controller = controller;
        }

        public ViewModelProperty<double?> Principle
        {
            get;
            private set;
        }

        public ViewModelProperty<double?> Rate
        {
            get;
            private set;
        }

        public ViewModelProperty<int?> Duration
        {
            get;
            private set;
        }

        public ViewModelProperty<double?> MonthlyPayment
        {
            get;
            private set;
        }

        public ViewModelProperty<double?> TotalPayment
        {
            get;
            private set;
        }

        public ViewModelProperty<bool> IsWaiting
        {
            get;
            private set;
        }

        public ViewModelProperty<string> Error
        {
            get;
            private set;
        }

        public ViewModelCommand<DelegateCommand> UpdateCommand
        {
            get;
            private set;
        }

        public void SetResult(double monthlyPayment, double totalPayment)
        {
            _model.MonthlyPayment = monthlyPayment;
            _model.TotalPayment = totalPayment;
            MonthlyPayment.RefreshValue();
            TotalPayment.RefreshValue();
        }

        protected override void CreateProperties()
        {
            Principle = Properties
                .NewProperty<double?>("Principle", () => _model.Principle)
                .WithDescription("Principle")
                .WithValidation(v => (v ?? 0) > 0)
                .WhenUpdated(RefreshUpdate)
                .Build();
            Rate = Properties
                .NewProperty<double?>("Rate", () => _model.Rate)
                .WithDescription("Rate")
                .WithValidation(v => (v ?? 0) > 0)
                .WhenUpdated(RefreshUpdate)
                .Build();
            Duration = Properties
                .NewProperty<int?>("Duration", () => _model.DurationInYears)
                .WithDescription("Duration")
                .WithValidation(v => (v ?? 0) > 0)
                .WhenUpdated(RefreshUpdate)
                .Build();
            MonthlyPayment = Properties
                .NewProperty<double?>("MonthlyPayment", () => _model.MonthlyPayment)
                .WithDescription("Monthly Payment")
                .WithFormat("#,##0.00")
                .WithEditability(false)
                .Build();
            TotalPayment = Properties
                .NewProperty<double?>("TotalPayment", () => _model.TotalPayment)
                .WithDescription("Total Payment")
                .WithFormat("#,##0.00")
                .WithEditability(false)
                .Build();
            IsWaiting = Properties
                .NewProperty<bool>("IsWaiting", () => false)
                .WithDescription("Waiting")
                .WhenUpdated(RefreshUpdate)
                .Build();
            Error = Properties
                .NewProperty<string>("Error", () => string.Empty)
                .WithVisibility(() => !string.IsNullOrEmpty(Error.Value))
                .WithDescription("Error")
                .Build();
        }

        protected override void CreateCommands()
        {
            UpdateCommand = Properties.NewCommand("Update", new DelegateCommand(TryUpdateResult, () => Properties.IsValid && !IsWaiting.Value));
        }

        private void RefreshUpdate()
        {
            UiContext.BeginInvoke(() => UpdateCommand.Command.UpdateCanExecute());
        }

        private void TryUpdateResult()
        {
            if (Properties.IsValid)
            {
                IsWaiting.Value = true;
                Error.Value = string.Empty;

                _controller.UpdateResults(this)
                    .ContinueWith(
                    r => SetResult(r.MonthlyPayment, r.TotalPayments),
                    e => Error.Value = "Uh oh, server communication error",
                    () => IsWaiting.Value = false);
            }
        }
    }
}
