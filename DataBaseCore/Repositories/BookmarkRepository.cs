using DataBaseCore.Entities;
using SQLite;
using SQLiteNetExtensions;
using System;
using System.Collections.Generic;

namespace DataBaseCore.Repositories
{
    public class BookmarkRepository
    {
        private readonly SQLiteConnection _database;

        internal BookmarkRepository(SQLiteConnection database) => _database = database;

        public List<Bookmark> GetItems() => _database.Table<Bookmark>().ToList();

        public int DeleteItem(Bookmark item)
        {
            if (Find(item.Guid) == null) return 0;
            return _database.Delete(item);
        }

        public Bookmark Find(Guid id)
        {
            try { return _database.Get<Bookmark>(id); }
            catch { return null; }
        }
        public int SaveItem(Bookmark item)
        {
            if (Find(item.Guid) != null)
            {
                return _database.Update(item);
            }
            return _database.Insert(item);
        }
    }
}
