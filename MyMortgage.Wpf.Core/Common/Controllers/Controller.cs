using MyMortgage.Wpf.Core.Common.ViewModel;

namespace MyMortgage.Wpf.Core.Common.Controllers
{
    public abstract class Controller<T> : IController where T : ViewModelBase
    {
        private bool _created;
        private readonly object _syncRoot = new object();

        public T ViewModel { get; private set; }

        protected object SyncRoot
        {
            get { return _syncRoot; }
        }

        public virtual void Create()
        {
            lock (SyncRoot)
            {
                if (!_created)
                {
                    _created = true;

                    this.Initialise();
                    this.ViewModel = this.CreateViewModel();
                }
            }
        }

        protected abstract T CreateViewModel();

        protected abstract void Initialise();
    }
}
