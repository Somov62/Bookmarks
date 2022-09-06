using Bookmarks.ViewModels;
using DataBaseCore.Entities;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookmarksPage : ContentPage
    {
        private readonly BookmarksVM _context;

        public BookmarksPage(Folder folder)
        {
            InitializeComponent();
            _context = new BookmarksVM(folder);
            BindingContext = _context;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await System.Threading.Tasks.Task.Delay(200);
            listview.SetBinding(ListView.ItemsSourceProperty, nameof(_context.BindCollection));
        }

        private async void Listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new WebViewPage(((Bookmark)e.Item).Url));
        }

        private async void OpenMenu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Bookmark model = btn.BindingContext as Bookmark;
            var result = await Navigation.ShowPopupAsync(new Popups.BookmarkMenuPopup(model));
            if (result == null) return;
            _context.OnPropertyChanged(nameof(_context.Folder));
            _context.OnPropertyChanged(nameof(_context.BindCollection));
        }

        private async void CreateBookmarkButton_Clicked(object sender, EventArgs e)
        {
            Bookmark bookmark = new Bookmark()
            {
                Guid = Guid.NewGuid(),
                FolderGuid = _context.Folder.Guid,
                Name = "",
                Url = ""
            };
            var result = await Navigation.ShowPopupAsync(new Popups.BookmarkMenuPopup(bookmark, false));
            if (result == null) return;
            _context.OnPropertyChanged(nameof(_context.Folder));
            _context.OnPropertyChanged(nameof(_context.BindCollection));
        }

        private async void OpenFolderMenu_Click(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new Popups.FolderMenuPopup(_context.Folder));
            if (result == null) return;
            if ((bool)result)
            {
                _context.OnPropertyChanged(nameof(_context.Folder));
                return;
            }
            await Navigation.PopAsync();
        }
    }
}