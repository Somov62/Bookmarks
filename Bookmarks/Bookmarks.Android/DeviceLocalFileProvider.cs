using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bookmarks.Interfaces;
using FFImageLoading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Bookmarks.Droid.DeviceLocalFileProvider))]

namespace Bookmarks.Droid
{
    internal class DeviceLocalFileProvider : IDeviceLocalFileProvider
    {
        private readonly string _rootDir = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "pdf");

        public string SaveFileToDisk(Stream pdfStream, string fileName)
        {
            if (!Directory.Exists(_rootDir))
                Directory.CreateDirectory(_rootDir);

            var filePath = Path.Combine(_rootDir, fileName);

            using (pdfStream)
            {
                File.WriteAllBytes(filePath, pdfStream.ToByteArray());
            }

            return filePath;
        }
    }
}