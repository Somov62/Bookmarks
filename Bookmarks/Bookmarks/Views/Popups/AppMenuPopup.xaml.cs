using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppMenuPopup : Popup
    {
        private readonly ViewModels.AppMenuVM _context = new ViewModels.AppMenuVM();
        public AppMenuPopup()
        {
            InitializeComponent();
            BindingContext = _context;
        }

        private async void OpenImport_Click(object sender, EventArgs e)
        {
            Dismiss("import");
        }
        
        private async void OpenSupport_Click(object sender, EventArgs e)
        {
            Dismiss("support");
        }

        private void ChangeTheme_Click(object sender, EventArgs e)
        {
            _context.ChangeThemeCommand.Execute(null);
            Dismiss("themes");
        }
    }
}