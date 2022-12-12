using Bookmarks.ViewModels;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoldersPage : ContentPage
    {
        private readonly FoldersVM _context = new FoldersVM();
        public FoldersPage()
        {
            InitializeComponent();
            _context.OpenFolderMenuEvent += OpenFolderMenuEvent;
            _context.OpenFolderEvent += OpenFolderEvent;
            BindingContext = _context;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _context.OnPropertyChanged(nameof(_context.FoldersList));
        }

        private async void OpenFolderMenuEvent(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new Popups.FolderMenuPopup((DataBaseCore.Entities.Folder)sender));
            if (result == null) return;
            _context.OnPropertyChanged(nameof(_context.FoldersList));
        }

        private async void CreateFolderButton_Clicked(object sender, EventArgs e)
        {
            var folderName = await Navigation.ShowPopupAsync(new Popups.AddFolderPopup());
            if (folderName == null) return;
            _context.CreateFolderCommand.Execute(folderName);
        }

        private async void OpenFolderEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookmarksPage((DataBaseCore.Entities.Folder)sender));
        }

        private async void OpenMenuButton_Clicked(object sender, EventArgs e)
        {
            string result = (string) await Navigation.ShowPopupAsync(new Popups.AppMenuPopup());
            if (result == null) return;
            if (result == "import")
            {
                await Navigation.PushAsync(new ImportPage());
                return;
            }
            if (result == "support")
            {
                await Navigation.PushAsync(new SupportPage());
                return;
            }
            OpenMenuButton_Clicked(this, null);
        }
    }
}