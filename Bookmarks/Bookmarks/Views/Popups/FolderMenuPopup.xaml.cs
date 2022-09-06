using DataBaseCore;
using DataBaseCore.Entities;
using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FolderMenuPopup : Popup
    {
        private readonly DbContext _context = DbContext.GetContext();
        private readonly Folder _folder;
        public FolderMenuPopup(Folder folder)
        {
            InitializeComponent();
            _folder = folder;
            folderBinding.BindingContext = _folder;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_folder.Name))
            {
                txtFolderName.PlaceholderColor = Color.Red;
                return;
            }
            if (string.IsNullOrWhiteSpace(_folder.Description))
            {
                txtFolderDescription.PlaceholderColor = Color.Red;
                return;
            }
            _context.FolderRepository.SaveItem(_folder);
            Dismiss(true);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            _context.FolderRepository.DeleteItem(_folder);
            Dismiss(false);
        }
    }
}