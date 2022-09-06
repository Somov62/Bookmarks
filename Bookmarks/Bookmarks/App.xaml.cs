using Bookmarks.Views;
using Xamarin.Forms;

namespace Bookmarks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Services.ThemeManager themeManager = new Services.ThemeManager();
            themeManager.SetStartUpTheme();

            MainPage = new NavigationPage(new FoldersPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
