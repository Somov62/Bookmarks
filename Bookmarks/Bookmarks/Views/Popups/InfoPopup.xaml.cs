using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPopup : Popup
    {
        public InfoPopup(string message, int height = 250)
        {
            InitializeComponent();
            txtInfo.Text = message;
            this.Size = new Xamarin.Forms.Size(300, height);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}