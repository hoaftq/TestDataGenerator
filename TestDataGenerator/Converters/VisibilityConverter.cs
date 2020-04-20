using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestDataGenerator.Converters
{
    [ValueConversion(typeof(bool?), typeof(Visibility), ParameterType = typeof(bool?))]
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visibleValue = (bool?)parameter ?? true;
            return ((bool?)value == visibleValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
