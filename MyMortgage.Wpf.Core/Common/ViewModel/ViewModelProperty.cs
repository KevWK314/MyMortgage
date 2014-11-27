using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    public class ViewModelProperty<T> : IViewModelProperty
    {
        private T _value;
        private bool _isUpdated;
        private bool _isValid = true;
        private bool _isEditable = true;
        private bool _isVisible = true;
        private string _format;
        private string _description;

        private readonly Func<T> _getDefault;
        private Predicate<T> _validation;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ValueUpdated;

        private struct Fields
        {
            public const string Description = "Description";
            public const string Value = "Value";
            public const string Format = "Format";
            public const string FormattedValue = "FormattedValue";
            public const string IsUpdated = "IsUpdated";
            public const string IsValid = "IsValid";
            public const string IsEditable = "IsEditable";
            public const string IsVisible = "IsVisible";
        }

        public string Name { get; private set; }

        public T Value
        {
            get
            {
                return this._isUpdated ? this._value : this._getDefault();
            }
            set
            {
                if (this.IsEditable)
                {
                    this._value = value;
                    this._isUpdated = true;
                    this._isValid = this._validation(value);
                    this.RaisePropertyChanged(Fields.Value);
                    this.RaisePropertyChanged(Fields.FormattedValue);
                    this.RaisePropertyChanged(Fields.IsUpdated);
                    this.RaisePropertyChanged(Fields.IsValid);
                    this.OnValueUpdated();
                }
            }
        }

        public string FormattedValue
        {
            get { return string.Format("{0:" + this._format + "}", this.Value); }
            set { }
        }

        public string Description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                this.RaisePropertyChanged(Fields.Description);
            }
        }

        public bool IsEditable
        {
            get { return this._isEditable; }
            set
            {
                this._isEditable = value;
                this.RaisePropertyChanged(Fields.IsEditable);
            }
        }

        public bool IsVisible
        {
            get { return this._isVisible; }
            set
            {
                this._isVisible = value;
                this.RaisePropertyChanged(Fields.IsVisible);
            }
        }

        public bool IsUpdated
        {
            get { return this._isUpdated; }
        }

        public bool IsValid
        {
            get { return this._isValid; }
        }

        public string Format
        {
            get { return this._format; }
            set
            {
                this._format = value;
                this.RaisePropertyChanged(Fields.Format);
                this.RaisePropertyChanged(Fields.FormattedValue);
            }
        }

        internal ViewModelProperty(string name, Func<T> getDefault)
        {
            this.Name = name;
            this._getDefault = getDefault ?? (() => default(T));
            this.SetValidation(null);
        }

        public void RefreshValue()
        {
            this.RaisePropertyChanged(Fields.Value);
            this.RaisePropertyChanged(Fields.FormattedValue);
            this.RaisePropertyChanged(Fields.IsValid);
        }

        public void RefreshAll()
        {
            this.RaisePropertyChanged(Fields.Value);
            this.RaisePropertyChanged(Fields.FormattedValue);
            this.RaisePropertyChanged(Fields.IsUpdated);
            this.RaisePropertyChanged(Fields.IsValid);
            this.RaisePropertyChanged(Fields.IsEditable);
            this.RaisePropertyChanged(Fields.IsVisible);
            this.RaisePropertyChanged(Fields.Format);
            this.RaisePropertyChanged(Fields.Description);
        }

        public void ResetValue()
        {
            this._isUpdated = false;
            this._isValid = this._validation(this.Value);
            this.RaisePropertyChanged(Fields.Value);
            this.RaisePropertyChanged(Fields.FormattedValue);
            this.RaisePropertyChanged(Fields.IsValid);
            this.RaisePropertyChanged(Fields.IsUpdated);
            this.OnValueUpdated();
        }

        internal void SetValidation(Predicate<T> validation)
        {
            this._validation = validation ?? (t => true);
        }

        private void RaisePropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void OnValueUpdated()
        {
            if (this.ValueUpdated != null)
            {
                this.ValueUpdated(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return this.FormattedValue;
        }

        public string GetSnapshot(bool full)
        {
            var result = this.FormattedValue ?? string.Empty;
            var details = new List<string>();
            if (full)
            {
                if (this.IsUpdated)
                {
                    details.Add(string.Format("IsUpdated={0}", this.IsUpdated));
                }
                if (!this.IsEditable)
                {
                    details.Add(string.Format("IsEditable={0}", this.IsEditable));
                }
                if (!this.IsVisible)
                {
                    details.Add(string.Format("IsVisible={0}", this.IsVisible));
                }
                if (!this.IsValid)
                {
                    details.Add(string.Format("IsValid={0}", this.IsValid));
                }
            }

            return details.Count == 0 
                ? result 
                : string.Format("{0} [{1}]", result, string.Join(",", details)).Trim();
        }
    }
}
