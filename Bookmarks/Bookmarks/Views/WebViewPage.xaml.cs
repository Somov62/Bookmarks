using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage(string url)
        {
            InitializeComponent();
            webview.Source = url;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Services.ColorManager colorService = new Services.ColorManager();
            colorService.SetStatusBarColor("WebViewStatusBarColor");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Services.ColorManager colorService = new Services.ColorManager();
            colorService.SetStatusBarColor("MainColor");
        }
    }
}