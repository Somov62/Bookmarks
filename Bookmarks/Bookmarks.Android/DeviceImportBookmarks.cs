using Bookmarks.Interfaces;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(Bookmarks.Droid.DeviceImportBookmarks))]

namespace Bookmarks.Droid
{
    public class DeviceImportBookmarks : IDeviceImportBookmarks
    {
        public void CopyBookmarksFileFromYandexBrowser(string destinationPath)
        {
            DeviceRootAccess rootAccess = new DeviceRootAccess();
            if (rootAccess.CheckRootAccess() == false) return;

            string pathToYandexBookmarks = "/data/user/0/com.yandex.browser/app_chromium/Default/Bookmarks";
            Java.Lang.Runtime.GetRuntime().Exec("su -c " + $"cat {pathToYandexBookmarks} > {destinationPath} exit");
            Thread.Sleep(200);
        }
    }
}