using System.IO;

namespace Bookmarks.Interfaces
{
    public interface IDeviceLocalFileProvider
    {
        string SaveFileToDisk(Stream pdfStream, string fileName);

    }
}
