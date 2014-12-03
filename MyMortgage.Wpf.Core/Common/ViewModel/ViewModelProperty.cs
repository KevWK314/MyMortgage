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
        private string _format;
        private string _description;

        private readonly Func<T> _getDefault;
        private Predicate<T> _validation;
        private Func<bool> _isVisible;

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
                return _isUpdated ? _value : _getDefault();
            }
            set
            {
                if (IsEditable)
                {
                    _value = value;
                    _isUpdated = true;
                    _isValid = _validation(value);
                    RaisePropertyChanged(Fields.Value);
                    RaisePropertyChanged(Fields.FormattedValue);
                    RaisePropertyChanged(Fields.IsUpdated);
                    RaisePropertyChanged(Fields.IsValid);
                    RaisePropertyChanged(Fields.IsVisible);
                    OnValueUpdated();
                }
            }
        }

        public string FormattedValue
        {
            get { return string.Format("{0:" + _format + "}", Value); }
            set { }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(Fields.Description);
            }
        }

        public bool IsEditable
        {
            get { return _isEditable; }
            set
            {
                _isEditable = value;
                RaisePropertyChanged(Fields.IsEditable);
            }
        }

        public bool IsVisible
        {
            get { return _isVisible == null || _isVisible(); }
            set
            {
                _isVisible = () => value;
                RaisePropertyChanged(Fields.IsVisible);
            }
        }

        public bool IsUpdated
        {
            get { return _isUpdated; }
        }

        public bool IsValid
        {
            get { return _isValid; }
        }

        public string Format
        {
            get { return _format; }
            set
            {
                _format = value;
                RaisePropertyChanged(Fields.Format);
                RaisePropertyChanged(Fields.FormattedValue);
            }
        }

        internal ViewModelProperty(string name, Func<T> getDefault)
        {
            Name = name;
            _getDefault = getDefault ?? (() => default(T));
            SetValidation(null);
        }

        public void RefreshValue()
        {
            RaisePropertyChanged(Fields.Value);
            RaisePropertyChanged(Fields.FormattedValue);
            RaisePropertyChanged(Fields.IsValid);
            RaisePropertyChanged(Fields.IsVisible);
        }

        public void RefreshAll()
        {
            RaisePropertyChanged(Fields.Value);
            RaisePropertyChanged(Fields.FormattedValue);
            RaisePropertyChanged(Fields.IsUpdated);
            RaisePropertyChanged(Fields.IsValid);
            RaisePropertyChanged(Fields.IsEditable);
            RaisePropertyChanged(Fields.IsVisible);
            RaisePropertyChanged(Fields.Format);
            RaisePropertyChanged(Fields.Description);
        }

        public void ResetValue()
        {
            _isUpdated = false;
            _isValid = _validation(Value);
            RaisePropertyChanged(Fields.Value);
            RaisePropertyChanged(Fields.FormattedValue);
            RaisePropertyChanged(Fields.IsValid);
            RaisePropertyChanged(Fields.IsUpdated);
            OnValueUpdated();
        }

        internal void SetValidation(Predicate<T> validation)
        {
            _validation = validation ?? (t => true);
            _isValid = _validation(Value);
            RaisePropertyChanged(Fields.IsValid);
        }

        public void SetVisibility(Func<bool> isVisible)
        {
            _isVisible = isVisible;
            RaisePropertyChanged(Fields.IsVisible);
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void OnValueUpdated()
        {
            if (ValueUpdated != null)
            {
                ValueUpdated(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return FormattedValue;
        }

        public string GetSnapshot(bool full)
        {
            var result = FormattedValue ?? string.Empty;
            var details = new List<string>();
            if (full)
            {
                if (IsUpdated)
                {
                    details.Add(string.Format("IsUpdated={0}", IsUpdated));
                }
                if (!IsEditable)
                {
                    details.Add(string.Format("IsEditable={0}", IsEditable));
                }
                if (!IsVisible)
                {
                    details.Add(string.Format("IsVisible={0}", IsVisible));
                }
                if (!IsValid)
                {
                    details.Add(string.Format("IsValid={0}", IsValid));
                }
            }

            return details.Count == 0 
                ? result 
                : string.Format("{0} [{1}]", result, string.Join(",", details)).Trim();
        }
    }
}
