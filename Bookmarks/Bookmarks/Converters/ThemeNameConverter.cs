using Bookmarks.Services;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Bookmarks.Converters
{
    public class ThemeNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Theme)value)
            {
                case Theme.Light:
                    return "Светлая";
                case Theme.Dark:
                    return "Тёмная";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
