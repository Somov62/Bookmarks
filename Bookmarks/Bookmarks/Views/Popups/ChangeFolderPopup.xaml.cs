using DataBaseCore.Entities;
using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeFolderPopup : Popup
    {
        public ChangeFolderPopup(List<Folder> folderList)
        {
            InitializeComponent();
            listview.ItemsSource = folderList;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Dismiss(btn.BindingContext);
        }
    }
}