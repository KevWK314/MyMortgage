using System.Collections.ObjectModel;
using MyMortgage.Wpf.Core.Common.ViewModel;

namespace MyMortgage.Wpf.Core.Common.Controllers
{
    public abstract class CollectionController<TParent, TChild> : Controller<TParent> where TParent : ViewModelBase
    {
        public ObservableCollection<TChild> Children
        {
            get;
            private set;
        }

        public override void Create()
        {
            this.Children = new ObservableCollection<TChild>();
            base.Create();
        }
    }
}
