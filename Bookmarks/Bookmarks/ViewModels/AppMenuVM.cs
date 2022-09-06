using Bookmarks.Services;
using Xamarin.Forms;

namespace Bookmarks.ViewModels
{
    public class AppMenuVM : Base.BaseVM
    {
        private readonly ThemeManager _themeManager = new ThemeManager();
        public Command ChangeThemeCommand { get; }

        public AppMenuVM()
        {
            ChangeThemeCommand = new Command(ChangeTheme);
        }

        public Theme ThemeName => _themeManager.GetCurrentTheme();

        private void ChangeTheme()
        {
            switch (ThemeName)
            {
                case Theme.Light:
                    _themeManager.SetTheme(Theme.Dark);
                    break;
                case Theme.Dark:
                    _themeManager.SetTheme(Theme.Light);
                    break;
            }
            OnPropertyChanged(nameof(ThemeName));
        }
    }
}
