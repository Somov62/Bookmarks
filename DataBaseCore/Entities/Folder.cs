using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DataBaseCore.Entities
{
    [Table(nameof(Folder))]
    public class Folder
    {
        [PrimaryKey, Column(nameof(Guid))]
        public Guid Guid { get; set; }


        [Column(nameof(Name)), NotNull()]
        public string Name { get; set; }


        [Column(nameof(Description))]
        public string Description { get; set; }


        [Column(nameof(ServiceName))]
        public string ServiceName { get; set; }


        [Column(nameof(IsServiceFolder))]
        public bool IsServiceFolder { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Bookmark> Bookmarks { get; set; }

    }
}
