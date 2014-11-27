using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMortgage.Wpf.Core.Components.Main
{
    public class MainViewModel
    {
        private readonly MainController _controller;

        public MainViewModel(MainController controller)
        {
            _controller = controller;
        }
    }
}
