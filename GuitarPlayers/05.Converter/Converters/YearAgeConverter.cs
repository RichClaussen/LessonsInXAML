using System;
using System.Globalization;
using System.Windows.Data;

namespace GuitarPlayers.Converters
{
    public class YearAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int)) return null;

            return DateTime.Now.Year - ((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return null;

            int age;
            int.TryParse(value.ToString(), out age);

            return DateTime.Now.Year - age;
        }
    }
}
