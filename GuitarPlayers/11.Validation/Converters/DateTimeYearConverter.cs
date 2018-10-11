using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GuitarPlayers.Converters
{
    public class DateTimeYearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime)) return DependencyProperty.UnsetValue;

            return ((DateTime)value).Year;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;

            int year;
            int.TryParse(value.ToString(), out year);

            return new DateTime(year, 1, 1);
        }
    }
}
