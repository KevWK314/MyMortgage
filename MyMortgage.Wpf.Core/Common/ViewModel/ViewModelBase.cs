using MyMortgage.Wpf.Core.Common.Context;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    using System.Collections.Generic;

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

        public Dictionary<string, string> GetSnapshot(bool full)
        {
            return Properties.GetSnapshot(full);
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
