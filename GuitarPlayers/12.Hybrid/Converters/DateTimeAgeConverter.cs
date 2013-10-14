using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GuitarPlayers.Converters
{
    public class DateTimeAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime)) return DependencyProperty.UnsetValue;

            return DateTime.Now.Year - ((DateTime)value).Year;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;

            int age;
            int.TryParse(value.ToString(), out age);

            return new DateTime(DateTime.Now.Year - age, 1, 1);
        }
    }
}
