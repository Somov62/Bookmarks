using System;
using System.Globalization;
using Xamarin.Forms;

namespace Bookmarks.Converters
{
    public class IconLoadUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string url = value.ToString();
            if (url.Contains("?"))
            {
                url = url.Substring(0, url.IndexOf('?'));
            }
            if (url.Contains("@"))
            {
                url = url.Substring(0, url.IndexOf('@'));
            }
            return $"https://t2.gstatic.com/faviconV2?client=SOCIAL&type=FAVICON&fallback_opts=TYPE,SIZE,URL&url={url}&size=256";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
