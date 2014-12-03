using System;

namespace MyMortgage.Wpf.Core.Common.Context
{
    public interface IUiContext
    {
        bool IsSynced { get; }

        void Invoke(Action action);
        void BeginInvoke(Action action);
    }
}
