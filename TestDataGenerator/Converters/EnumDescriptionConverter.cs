using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace TestDataGenerator.Converters
{
    [ValueConversion(typeof(Enum), typeof(string))]
    class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = value as Enum;
            var field = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttr = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            if (descriptionAttr != null)
            {
                return descriptionAttr.Description;
            }

            return enumValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
