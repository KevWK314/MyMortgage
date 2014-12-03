using System;

namespace MyMortgage.Wpf.Core.Common.Context
{
    using System.Threading;
    using System.Windows.Threading;

    public class UiContext : IUiContext
    {
        private readonly Dispatcher _dispatcher;

        public UiContext()
            : this(Dispatcher.CurrentDispatcher)
        {
        }

        public UiContext(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public bool IsSynced
        {
            get { return _dispatcher.Thread == Thread.CurrentThread; }
        }

        public void Invoke(Action action)
        {
            if (action != null)
            {
                _dispatcher.Invoke(action);
            }
        }

        public void BeginInvoke(Action action)
        {
            if (action != null)
            {
                _dispatcher.BeginInvoke(action);
            }
        }
    }
}
