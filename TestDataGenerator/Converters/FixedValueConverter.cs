using System;
using System.Globalization;
using System.Windows.Data;

namespace TestDataGenerator.Converters
{
    public class FixedValueConverter : IValueConverter
    {
        public object Value { get; set; }

        public object NewValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Value == value || (Value?.Equals(value) ?? false))
            {
                return NewValue;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
