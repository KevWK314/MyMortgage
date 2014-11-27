using System;
using System.Windows;
using System.Windows.Data;

namespace MyMortgage.Wpf.Core.Common.Converter
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isVisible = (bool) value;
            return !this.Inverted ? this.GetVisibility(isVisible) : this.GetVisibility(!isVisible);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private Visibility GetVisibility(bool isVisible)
        {
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
