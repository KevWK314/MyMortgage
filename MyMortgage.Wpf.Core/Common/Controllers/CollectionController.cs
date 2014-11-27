using System.Collections.ObjectModel;

namespace MyMortgage.Wpf.Core.Common.Controllers
{
    public abstract class CollectionController<TParent, TChild> : Controller<TParent>
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
