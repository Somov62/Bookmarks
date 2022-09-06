using System;

namespace DataBaseCore
{
    public partial class DbContext
    {
        private static readonly string _connectionString = System.IO.Path.Combine
           (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BookmarksLocalDb");

        private static DbContext _context;

        public static DbContext GetContext()
        {
            if (_context == null)
            {
                _context = new DbContext(_connectionString);
            }
            return _context;
        }
    }
}
