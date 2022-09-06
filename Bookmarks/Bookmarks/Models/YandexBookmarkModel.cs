using System.Collections.Generic;

namespace Bookmarks.Models
{

    public class YandexBookmarksModel
    {
        public Data roots { get; set; }

        public class Data
        {
            public BookmarkCollection bookmark_bar { get; set; }
            public BookmarkCollection other { get; set; }
            public BookmarkCollection synced { get; set; }
        }

        public class BookmarkCollection
        {
            public List<Bookmark> children { get; set; }
            public string guid { get; set; }
            public string name { get; set; }
        }

        public class Bookmark
        {
            public string guid { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

    }

   
}
