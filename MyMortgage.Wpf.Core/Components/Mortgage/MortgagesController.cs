using System;
using System.Threading.Tasks;

using MyMortgage.Common.Validation;
using MyMortgage.RestApi.Client;
using MyMortgage.RestApi.Common.Dto;
using MyMortgage.Wpf.Core.Common.Controllers;
using MyMortgage.Wpf.Core.Components.Factory;

namespace MyMortgage.Wpf.Core.Components.Mortgage
{
    public class MortgagesController : CollectionController<MortgagesViewModel, MortgageViewModel>
    {
        private readonly IMyMortgageClient _client;
        private readonly IViewModelFactory _viewModelFactory;

        public MortgagesController(IMyMortgageClient client, IViewModelFactory viewModelFactory)
        {
            _client = client;
            _viewModelFactory = viewModelFactory;
        }

        protected override MortgagesViewModel CreateViewModel()
        {
            return _viewModelFactory.CreateMortgagesViewModel(this);
        }

        protected override void Initialise()
        {
        }

        public void AddNewMortgage()
        {
            var newViewModel = _viewModelFactory.CreateMortgageViewModel(this);
            Children.Add(newViewModel);
        }

        public async Task<MonthlyPaymentsResponse> UpdateResults(MortgageViewModel mortgage)
        {
            Ensure.That(Value.IsNotNull(mortgage), () => new ArgumentNullException("mortgage"));

            var request = new MonthlyPaymentsRequest
            {
                Principle = mortgage.Principle.Value ?? 0,
                Rate = mortgage.Rate.Value ?? 0,
                DurationInMonths = (mortgage.Duration.Value ?? 0) * 12
            };

            return await _client.GetMonthlyPaymentAsync(request);
        }
    }
}
