using System;
using System.ComponentModel;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    public interface IViewModelProperty : INotifyPropertyChanged
    {
        event EventHandler ValueUpdated;

        string Name { get; }
        string Description { get; }
        string FormattedValue { get; }
        bool IsUpdated { get; }
        bool IsValid { get; }

        void RefreshValue();
        void RefreshAll();
        void ResetValue();
        string GetSnapshot(bool full);
    }
}
