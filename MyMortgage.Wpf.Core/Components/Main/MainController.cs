using System;

using MyMortgage.RestApi.Client;
using MyMortgage.Wpf.Core.Common.Controllers;
using MyMortgage.Wpf.Core.Components.Factory;
using MyMortgage.Wpf.Core.Components.Mortgage;

namespace MyMortgage.Wpf.Core.Components.Main
{
    using System.Threading.Tasks;

    public class MainController : Controller<MainViewModel>
    {
        private readonly IMyMortgageClient _client;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly MortgagesController _mortgagesController;

        public MortgagesViewModel MortgagesViewModel
        {
            get { return _mortgagesController.ViewModel; }
        }

        public MainController(
            IMyMortgageClient client,
            IViewModelFactory viewModelFactory, 
            MortgagesController mortgagesController)
        {
            _client = client;
            _viewModelFactory = viewModelFactory;
            _mortgagesController = mortgagesController;
        }

        protected override MainViewModel CreateViewModel()
        {
            return _viewModelFactory.CreateMainViewModel(this);
        }

        protected override void Initialise()
        {
        }

        public async Task<bool> IsServerAvailable()
        {
            return await _client.IsServiceOkAsync();
        }
    }
}
