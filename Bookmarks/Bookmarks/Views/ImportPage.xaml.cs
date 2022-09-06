using Bookmarks.Services;
using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bookmarks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportPage : ContentPage
    {
        public ImportPage()
        {
            InitializeComponent();
        }

        private async void ImportFromYB_Clicked(object sender, EventArgs e)
        {
            btnImportYb.IsEnabled = false;
            await Task.Delay(100);
            if (!DependencyService.Get<Interfaces.IDeviceRootAccess>().CheckRootAccess())
            {
                btnImportYb.IsEnabled = true;
                await Navigation.ShowPopupAsync(new Popups.InfoPopup("Извините, без рут-прав мы не сможем импортировать закладки"));
                return;
            }
            ImportService importService = new ImportService();
            DataBaseCore.Entities.Folder folder = await Task.Run(importService.ImportFromYandexBrowser);
            if (folder == null)
            {
                string errormessage = $"Упс...\n\nИмпорт завершился с ошибками.\n\nПроверьте наличие яндекс браузера и закладок в нём.";
                await Navigation.ShowPopupAsync(new Popups.InfoPopup(errormessage, 300));
                btnImportYb.IsEnabled = true;
                return;
            }
            string message = $"Успех!\n\nЗакладок добавлено: {folder.Bookmarks.Count}\n\nСохранили их в папке: {folder.Name}";
            await Navigation.ShowPopupAsync(new Popups.InfoPopup(message));
            await Navigation.PopAsync();

        }
    }
}