using DataBaseCore.Entities;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseCore.Repositories
{
    public class FolderRepository
    {
        private readonly SQLiteConnection _database;
        private readonly DbContext _context;

        internal FolderRepository(DbContext context)
        {
            _context = context;
            _database = _context.Database;
        }

        public List<Folder> GetItems()
        {
            var list = new List<Folder>();
            foreach (var item in _database.Table<Folder>().ToList())
            {
                list.Add(_database.GetWithChildren<Folder>(item.Guid));
            }
            return list;
        }

        public int DeleteItem(Folder item, bool deleteChildren = true)
        {
            if (Find(item.Guid) == null) return 0;

            if (deleteChildren)
            {
                foreach (var bookmark in item.Bookmarks)
                {
                    _context.BookmarkRepository.DeleteItem(bookmark);
                }
            }

            return _database.Delete(item);
        }

        public Folder DeleteChildrens(Folder item)
        {
            if (Find(item.Guid) == null) return null;
            foreach (var bookmark in item.Bookmarks)
            {
                _context.BookmarkRepository.DeleteItem(bookmark);
            }
            return Find(item.Guid);
        }

        public Folder Find(Guid id)
        {
            try { return _database.GetWithChildren<Folder>(id); }
            catch { return null; }
        }
        public void SaveItem(Folder item)
        {
            if (Find(item.Guid) != null)
            {
                //var oldFolder = Find(item.Guid);

                foreach (Bookmark bookmark in item.Bookmarks)
                {
                    _context.BookmarkRepository.SaveItem(bookmark);
                }

                _database.UpdateWithChildren(item);
                return;
            }
            _database.InsertWithChildren(item);
        }

    }
}
