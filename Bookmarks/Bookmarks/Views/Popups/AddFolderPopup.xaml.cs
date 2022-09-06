using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFolderPopup : Popup
    {
        public string[] placeHolders =
        {
            "Про уход за растениями",
            "Сборник статей",
            "Книга рецептов",
            "Папка анекдотов",
            "Полезные лайфхаки",
            "Милые коты",
            "Работа",
            "Учёба",
            "Важные новости",
            "Обучающие материалы",
            "Компромат на друзей",
            "Папка закладок"
        };
        public AddFolderPopup()
        {
            InitializeComponent();
            Random rnd = new Random();
            textbox.Placeholder = placeHolders[rnd.Next(placeHolders.Length)];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                textbox.PlaceholderColor = Color.Red;
                return;
            }
            Dismiss(textbox.Text);

        }
    }
}