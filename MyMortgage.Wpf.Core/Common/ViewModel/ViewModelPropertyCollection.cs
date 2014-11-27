using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    public class ViewModelPropertyCollection
    {
        private readonly List<IViewModelProperty> _properties = new List<IViewModelProperty>();
        private readonly List<IViewModelCommand> _commands = new List<IViewModelCommand>();

        public event EventHandler PropertyValueUpdated;

        public bool IsUpdated
        {
            get { return this._properties.Any(p => p.IsUpdated); }
        }

        public bool IsValid
        {
            get { return this._properties.All(p => p.IsValid); }
        }

        public ViewModelPropertyBuilder<T> New<T>(string name, Func<T> getDefaultValue)
        {
            var builder = new ViewModelPropertyBuilder<T>(name, getDefaultValue);
            this._properties.Add(builder.Property);
            builder.Property.ValueUpdated += (s, a) => this.OnPropertyValueUpdated();
            return builder;
        }

        public ViewModelCommand<T> NewCommand<T>(string name, T command) where T : ICommand
        {
            var vmCommand = new ViewModelCommand<T>(name, command);
            this._commands.Add(vmCommand);
            return vmCommand;
        }

        public void ResetValues()
        {
            this._properties.ForEach(p => p.ResetValue());
        }

        public void RefreshValues()
        {
            this._properties.ForEach(p => p.RefreshValue());
        }

        public Dictionary<string, string> GetSnapshot(bool full)
        {
            var details = new Dictionary<string, string>();
            this._properties.ForEach(p => details[p.Name] = p.GetSnapshot(full));
            this._commands.ForEach(c => details[c.Name] = c.GetSnapshot());
            return details;
        }

        private void OnPropertyValueUpdated()
        {
            if (this.PropertyValueUpdated != null)
            {
                this.PropertyValueUpdated(this, EventArgs.Empty);
            }
        }
    }
}
