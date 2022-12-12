using Bookmarks.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportPage : ContentPage
    {
        public SupportPage()
        {
            InitializeComponent();

            wb1.Source = new HtmlWebViewSource
            {
                Html = $"<body\"><img src=\"Folder.gif\" alt=\"A Gif file\" width=\"{600}\"  style=\"width: 100%; height: auto;\"/></body>",
                BaseUrl = "file:///android_asset/"
            };
            wb2.Source = new HtmlWebViewSource
            {
                Html = $"<body\"><img src=\"Bookmark.gif\" alt=\"A Gif file\" width=\"{600}\"  style=\"width: 100%; height: auto;\"/></body>",
                BaseUrl = "file:///android_asset/"
            };
            wb3.Source = new HtmlWebViewSource
            {
                Html = $"<body\"><img src=\"ReplaceBookmark.gif\" alt=\"A Gif file\" width=\"{600}\"  style=\"width: 100%; height: auto;\"/></body>",
                BaseUrl = "file:///android_asset/"
            };
            wb4.Source = new HtmlWebViewSource
            {
                Html = $"<body\"><img src=\"Theme.gif\" alt=\"A Gif file\" width=\"{600}\"  style=\"width: 100%; height: auto;\"/></body>",
                BaseUrl = "file:///android_asset/"
            };
            wb5.Source = new HtmlWebViewSource
            {
                Html = $"<body\"><img src=\"Import.gif\" alt=\"A Gif file\" width=\"{600}\"  style=\"width: 100%; height: auto;\"/></body>",
                BaseUrl = "file:///android_asset/"
            };
        }

        private void OpenDocumentButton_Click(object sender, EventArgs e)
        {
            var localPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "pdf", "support.pdf");
            string url = $"file:///android_asset/pdfjs/web/viewer.html?file={System.Net.WebUtility.UrlEncode(localPath)}";
            this.Navigation.PushAsync(new WebViewPage(url));
        }
    }
}