using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GuitarPlayers.Converters
{
    public class YearAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int)) return DependencyProperty.UnsetValue;

            return DateTime.Now.Year - ((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;

            int age;
            int.TryParse(value.ToString(), out age);

            return DateTime.Now.Year - age;
        }
    }
}
