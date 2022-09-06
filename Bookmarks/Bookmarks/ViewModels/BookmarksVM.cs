using DataBaseCore;
using DataBaseCore.Entities;
using System;
using System.Collections.Generic;

namespace Bookmarks.ViewModels
{
    public class BookmarksVM : Base.BaseVM
    {
        private readonly Guid _folderGuid;
        private readonly DbContext _db = DbContext.GetContext();

        public BookmarksVM(Folder folder)
        {
            _folderGuid = folder.Guid;
            Title = folder.Name;
        }

        public Folder Folder => _db.FolderRepository.Find(_folderGuid);

        public List<Bookmark> BindCollection => Folder.Bookmarks;
    }
}
