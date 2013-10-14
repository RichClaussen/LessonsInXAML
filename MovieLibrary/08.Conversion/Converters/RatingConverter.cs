using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MovieLibrary.Converters
{
    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double)) return DependencyProperty.UnsetValue;

            var rating = (double)value;

            return rating > 3.0 ? rating : 2.0 * rating;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
