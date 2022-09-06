using DataBaseCore.Entities;
using DataBaseCore.Repositories;
using SQLite;
using System.Collections.Generic;
using System;

namespace DataBaseCore
{
    public partial class DbContext
    {
        private readonly SQLiteConnection _database;
        public DbContext(string databasePath)
        {
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<Entities.Bookmark>();
            _database.CreateTable<Entities.Folder>();
            FolderRepository = new FolderRepository(this);
            BookmarkRepository = new BookmarkRepository(_database);
        }

        public SQLiteConnection Database => _database;

        public FolderRepository FolderRepository { get; }
        public BookmarkRepository BookmarkRepository { get; }
    }
}
