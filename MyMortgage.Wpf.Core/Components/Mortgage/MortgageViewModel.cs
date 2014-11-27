using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMortgage.Wpf.Core.Components.Mortgage
{
    public class MortgageViewModel
    {
        private readonly MortgagesController _controller;

        public MortgageViewModel(MortgagesController controller)
        {
            _controller = controller;
        }
    }
}
