using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GuitarPlayers.Converters
{
    public class NameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2) return DependencyProperty.UnsetValue;

            var firstName = values[0].ToString();
            var lastName = values[1].ToString();

            return string.Format("{0} {1}", firstName, lastName);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
