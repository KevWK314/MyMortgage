using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMortgage.Wpf.Core.Components.Mortgage
{
    public class MortgagesViewModel
    {
        private readonly MortgagesController _controller;

        public MortgagesViewModel(MortgagesController controller)
        {
            _controller = controller;
        }
    }
}
