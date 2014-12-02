﻿using MyMortgage.RestApi.Client;
using MyMortgage.Wpf.Core.Common.Controllers;
using MyMortgage.Wpf.Core.Components.Factory;

namespace MyMortgage.Wpf.Core.Components.Mortgage
{
    using System;

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

        public void UpdateResults(MortgageViewModel mortgage)
        {
            // Get Result

            mortgage.SetResult(1, 25);
        }
    }
}
