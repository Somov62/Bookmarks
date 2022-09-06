using Bookmarks.Interfaces;
using Xamarin.Forms;

namespace Bookmarks.Services
{
    internal class ColorManager
    {

        public void SetNavBarColor(string appResourceColorName)
        {
            string hex = GetHexColorFromResource(appResourceColorName);
            DependencyService.Get<IDeviceColorManager>().SetNavBarColor(hex);
        }

        public void SetStatusBarColor(string appResourceColorName)
        {
            string hex = GetHexColorFromResource(appResourceColorName);
            DependencyService.Get<IDeviceColorManager>().SetStatusBarColor(hex);
        }

        public void SetTitleColor(string appResourceColorName)
        {
            string hex = GetHexColorFromResource(appResourceColorName);
            DependencyService.Get<IDeviceColorManager>().SetTitleColor(hex);
        }

        private string GetHexColorFromResource(string appResourceColorName)
        {
            Application.Current.Resources.TryGetValue(appResourceColorName, out var resource);
            Color color = (Color)resource;
            return string.Format("#{0:X2}{1:X2}{2:X2}", (int)(color.R * 255), (int)(color.G * 255), (int)(color.B * 255));
        }
    }
}
