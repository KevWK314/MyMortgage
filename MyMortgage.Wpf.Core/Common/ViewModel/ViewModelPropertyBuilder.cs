using System;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    public class ViewModelPropertyBuilder<T>
    {
        private readonly ViewModelProperty<T> _property;

        internal ViewModelProperty<T> Property
        {
            get { return this._property; }
        }

        internal ViewModelPropertyBuilder(string name, T defaultValue)
            : this(name, () => defaultValue)
        {
        }

        internal ViewModelPropertyBuilder(string name, Func<T> getDefault)
        {
            this._property = new ViewModelProperty<T>(name, getDefault);
        }

        public ViewModelPropertyBuilder<T> WithValidation(Predicate<T> validation)
        {
            this._property.SetValidation(validation);
            return this;
        }

        public ViewModelPropertyBuilder<T> WithFormat(string format)
        {
            this._property.Format = format;
            return this;
        }

        public ViewModelPropertyBuilder<T> WithDescription(string description)
        {
            this._property.Description = description;
            return this;
        }

        public ViewModelPropertyBuilder<T> WithEditability(bool isEditable)
        {
            this._property.IsEditable = isEditable;
            return this;
        }

        public ViewModelPropertyBuilder<T> WithVisibility(Func<bool> isVisible)
        {
            this._property.SetVisibility(isVisible);
            return this;
        }

        public ViewModelPropertyBuilder<T> WhenUpdated(Action whenUpdated)
        {
            this._property.ValueUpdated += (s, a) => whenUpdated();
            return this;
        }

        public ViewModelProperty<T> Build()
        {
            return this._property;
        }
    }
}
