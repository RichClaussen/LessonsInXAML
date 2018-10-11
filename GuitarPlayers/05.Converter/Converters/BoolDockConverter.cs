using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace GuitarPlayers.Converters
{
    public class BoolDockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool)) return null;

            return ((bool)value) ? Dock.Top : Dock.Bottom;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
