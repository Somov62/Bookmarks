using DataBaseCore;
using DataBaseCore.Entities;
using System.Linq;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookmarkMenuPopup : Popup
    {
        private readonly DbContext _context = DbContext.GetContext();
        private readonly Bookmark _bookmark;
        private readonly string _oldUrl;
        public BookmarkMenuPopup(Bookmark bookmark, bool isEditing = true)
        {
            InitializeComponent();
            _bookmark = bookmark;
            _oldUrl = _bookmark.Url;
            btnDelete.IsVisible = isEditing;
            btnReplace.IsVisible = isEditing;
            if (!isEditing)
            {
                this.Size = new Size(300, 370);
            }
            bookmarkBinding.BindingContext = _bookmark;
        }

        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(_bookmark.Name))
            {
                txtBookmarkName.PlaceholderColor = Color.Red;
                return false;
            }
            if (string.IsNullOrWhiteSpace(_bookmark.Url))
            {
                txtBookmarkUrl.PlaceholderColor = Color.Red;
                return false;
            }
            if (_oldUrl != _bookmark.Url)
            {
                if (_bookmark.Url.Length < 7 || (_bookmark.Url.Substring(0, 7) != "http://" && _bookmark.Url.Substring(0, 7) != "https:/"))
                {
                    _bookmark.Url = _bookmark.Url.Insert(0, "https://");
                }
            }
            _context.BookmarkRepository.SaveItem(_bookmark);
            return true;
        }


        private void Save_Clicked(object sender, System.EventArgs e)
        {
            if (Save()) Dismiss(_bookmark);
        }

        private void Delete_Click(object sender, System.EventArgs e)
        {
            _context.BookmarkRepository.DeleteItem(_bookmark);
            Dismiss(_bookmark);
        }

        private async void ChangeFolder_Clicked(object sender, System.EventArgs e)
        {
            if (!Save()) return;

            var folderList = _context.FolderRepository.GetItems();
            folderList = folderList.Where(p => p.Guid != _bookmark.FolderGuid).ToList();
            var result = await Navigation.ShowPopupAsync(new Popups.ChangeFolderPopup(folderList));
            if (result == null) return;

            Folder folder = result as Folder;
            _bookmark.FolderGuid = folder.Guid;
            _context.BookmarkRepository.SaveItem(_bookmark);
            Dismiss(_bookmark);
        }
    }
}