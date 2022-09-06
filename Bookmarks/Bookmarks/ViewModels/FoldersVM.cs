using DataBaseCore;
using DataBaseCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bookmarks.ViewModels
{
    public class FoldersVM : Base.BaseVM
    {
        private readonly DbContext _db = DbContext.GetContext();

        public ICommand CreateFolderCommand { get; }
        public ICommand OpenMenuCommand { get; }
        public ICommand OpenFolderCommand { get; }
        public FoldersVM()
        {
            CreateFolderCommand = new Command((folderName) => CreateFolder(folderName.ToString()));
            OpenMenuCommand = new Command((object item) => OpenFolderMenuEvent.Invoke(item, null));
            OpenFolderCommand = new Command((object item) => OpenFolderEvent.Invoke(item, null));
        }

        public List<Folder> FoldersList => _db.FolderRepository.GetItems().ToList();

        private void CreateFolder(string folderName)
        {
            Folder folder = new Folder()
            {
                Name = folderName,
                Description = "Добавьте описание для папки",
                Guid = Guid.NewGuid()
            };

            _db.FolderRepository.SaveItem(folder);
            OnPropertyChanged(nameof(FoldersList));

        }

        public event EventHandler OpenFolderMenuEvent;
        public event EventHandler OpenFolderEvent;

    }
}
