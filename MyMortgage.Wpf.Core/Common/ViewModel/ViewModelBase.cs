using MyMortgage.Wpf.Core.Common.Context;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    public abstract class ViewModelBase
    {
        private readonly ViewModelPropertyCollection _properties = new ViewModelPropertyCollection();

        protected ViewModelBase(IUiContext uiContext)
        {
            UiContext = uiContext;

            CreateProperties();
            CreateCommands();
        }

        public IUiContext UiContext
        {
            get;
            private set;
        }

        protected ViewModelPropertyCollection Properties
        {
            get { return _properties; }
        }

        protected virtual void CreateProperties()
        {
        }

        protected virtual void CreateCommands()
        {
        }
    }
}
