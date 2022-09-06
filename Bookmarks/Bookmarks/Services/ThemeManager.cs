using System;
using System.Linq;
using Xamarin.Forms;

namespace Bookmarks.Services
{
    public class ThemeManager
    {
        private const string _propertyName = "ThemeName";

        public Theme GetCurrentTheme()
        {
            ResourceDictionary theme = GetCurrentResource();
            if (theme == null)
            {
                SetTheme(Theme.Light);
                return Theme.Light;
            }

            switch (theme.GetType().Name)
            {
                case "LightTheme":
                    return Theme.Light;

                case "DarkTheme":
                    return Theme.Dark;
                default:
                    SetTheme(Theme.Light);
                    return Theme.Light;
            }
        }


        public void SetStartUpTheme()
        {
            App.Current.Properties.TryGetValue(_propertyName, out object property);
            if (!Enum.TryParse(property?.ToString(), out Theme theme))
            {
                theme = Theme.Light;
                App.Current.Properties[_propertyName] = theme.ToString();
            }
            SetTheme(theme);
        }

        public void SetTheme(Theme theme)
        {
            DeleteOldTheme();
            switch (theme)
            {
                case Theme.Light:
                    Application.Current.Resources.MergedDictionaries.Add(new Themes.LightTheme());
                    break;
                case Theme.Dark:
                    Application.Current.Resources.MergedDictionaries.Add(new Themes.DarkTheme());
                    break;
            }
            App.Current.Properties[_propertyName] = theme.ToString();
            ColorManager colorManager = new ColorManager();
            colorManager.SetNavBarColor("NavBarColor");
            colorManager.SetStatusBarColor("StatusBarColor");
        }

        private void DeleteOldTheme()
        {
            ResourceDictionary theme = GetCurrentResource();
            Application.Current.Resources.MergedDictionaries.Remove(theme);
        }

        private ResourceDictionary GetCurrentResource()
        {
            return Application.Current.Resources.MergedDictionaries.FirstOrDefault(p => p.GetType().ToString().Contains("Theme"));
        }

    }

    public enum Theme
    {
        Light,
        Dark
    }
}
