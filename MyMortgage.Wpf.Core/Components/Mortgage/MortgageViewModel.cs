using MyMortgage.Wpf.Core.Common.ViewModel;
using MyMortgage.Wpf.Core.Components.Mortgage.Model;

namespace MyMortgage.Wpf.Core.Components.Mortgage
{
    public class MortgageViewModel
    {
        private readonly MortgagesController _controller;
        private readonly ViewModelPropertyCollection _properties = new ViewModelPropertyCollection();

        private double? _monthlyPayment;
        private double? _totalPayment;

        public MortgageViewModel(MortgagesController controller)
        {
            _controller = controller;
            CreateProperties();
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

        public void SetResult(double monthlyPayment, double totalPayment)
        {
            _monthlyPayment = monthlyPayment;
            _totalPayment = totalPayment;
            MonthlyPayment.RefreshValue();
            TotalPayment.RefreshValue();
        }

        public void ClearResult()
        {
            MonthlyPayment.ResetValue();
            TotalPayment.ResetValue();
        }

        private void CreateProperties()
        {
            Principle = _properties
                .NewProperty<double?>("Principle", () => null)
                .WithDescription("Principle")
                .WithValidation(v => (v ?? 0) > 0)
                .WhenUpdated(TryUpdateResult)
                .Build();
            Rate = _properties
                .NewProperty<double?>("Rate", () => null)
                .WithDescription("Rate")
                .WithValidation(v => (v ?? 0) > 0)
                .WhenUpdated(TryUpdateResult)
                .Build();
            Duration = _properties
                .NewProperty<int?>("Duration", () => 25)
                .WithDescription("Duration")
                .WithValidation(v => (v ?? 0) > 0)
                .WhenUpdated(TryUpdateResult)
                .Build();
            MonthlyPayment = _properties
                .NewProperty<double?>("MonthlyPayment", () => _monthlyPayment)
                .WithDescription("Monthly Payment")
                .WithEditability(false)
                .Build();
            TotalPayment = _properties
                .NewProperty<double?>("TotalPayment", () => _totalPayment)
                .WithDescription("Total Payment")
                .WithEditability(false)
                .Build();
        }

        private void TryUpdateResult()
        {
            if (_properties.IsValid)
            {
                _controller.UpdateResults(this);
            }
        }
    }
}
