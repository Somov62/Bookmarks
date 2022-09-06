using DataBaseCore;
using DataBaseCore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Bookmarks.Services
{
    public class ImportService
    {
        private readonly string _innerStoragePath;
        public ImportService()
        {
            _innerStoragePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Bookmarks");
            ConfigureFolder();
        }

        public Folder ImportFromYandexBrowser()
        {
            string pathToFile = Path.Combine(_innerStoragePath, "YandexBookmarks.bak");
            if (!File.Exists(pathToFile)) File.Create(pathToFile).Close();

            DependencyService.Get<Interfaces.IDeviceImportBookmarks>().CopyBookmarksFileFromYandexBrowser(Path.Combine(pathToFile));

            string json = File.ReadAllText(pathToFile);
            if (string.IsNullOrEmpty(json)) return null;

            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.YandexBookmarksModel>(json);
            if (model == null) return null;

            Guid folderGuid = Guid.NewGuid();
            Folder folder = new Folder()
            {
                Bookmarks = new List<Bookmark>(),
                Guid = folderGuid,
                Name = "Яндекс браузер",
                ServiceName = "YandexImportFolder",
                IsServiceFolder = true,
                Description = "Импортировано из яндекс браузера"
            };

            Folder FillFoldresFromModel(List<Models.YandexBookmarksModel.Bookmark> source)
            {
                foreach (var item in source)
                {
                    folder.Bookmarks.Add(
                        new Bookmark()
                        {
                            FolderGuid = folderGuid,
                            Name = item.name,
                            Url = item.url,
                            //Guid = Guid.Parse(item.guid),
                            Guid = Guid.NewGuid(),
                        });
                }
                return folder;
            }
            FillFoldresFromModel(model.roots.bookmark_bar.children);
            FillFoldresFromModel(model.roots.other.children);
            FillFoldresFromModel(model.roots.synced.children);

            SaveInDatabase(folder);

            return folder;
        }


        private void ConfigureFolder()
        {
            Directory.CreateDirectory(_innerStoragePath);
        }

        private void SaveInDatabase(Folder folder)
        {
            DbContext db = DbContext.GetContext();

            if (folder.IsServiceFolder)
            {
                var dbFolder = db.FolderRepository.GetItems().Where(p => p.ServiceName == folder.ServiceName).FirstOrDefault();
                if (dbFolder != null)
                {
                    db.FolderRepository.DeleteItem(dbFolder);
                }
            }

            db.FolderRepository.SaveItem(folder);
        }

    }
}
