using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DataBaseCore.Entities
{
    [Table(nameof(Bookmark))]
    public class Bookmark
    {
        [PrimaryKey, Column(nameof(Guid))]
        public Guid Guid { get; set; }


        [Column(nameof(FolderGuid)), ForeignKey(typeof(Folder))]
        public Guid FolderGuid { get; set; }


        [Column(nameof(Name)), NotNull()]
        public string Name { get; set; }


        [Column(nameof(Url)), NotNull()]
        public string Url { get; set; }


        [Column(nameof(IconBase64))]
        public string IconBase64 { get; set; }


        [ManyToOne]
        public Folder Folder { get; set; }

    }
}
