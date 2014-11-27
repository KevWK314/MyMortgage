using System.Windows.Input;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    public interface IViewModelCommand : ICommand
    {
        string Name { get; }

        string GetSnapshot();
    }
}
