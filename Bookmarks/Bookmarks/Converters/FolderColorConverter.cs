using System;
using System.Globalization;
using Xamarin.Forms;

namespace Bookmarks.Converters
{
    public class FolderColorConverter : IValueConverter
    {
        private readonly string[] _colors = new[]
        {
            "FDD9B5", "7FFFD4", "78DBE2", "AB274F", "78A2B7", "F19CBB", "9F2B68", "01796F", "47A76A", "EB4C42",
            "FFB841", "009B77", "755D9A", "D53032", "7851A9", "3F888F", "0095B6", "FFCF40", "009B76", "1E90FF",
            "228B22", "2F4F4F", "1C6B72", "EC7C26", "8CCB5E", "808000", "B784A7", "1E5945", "FFA500", "BD33A4",
            "77DDE7", "FFCF48", "DAD871", "F8173E", "008000", "00A550", "98FB98", "B2EC5D", "6A5ACD", "7442C8",
            "CED23A", "9D81BA", "D77D31", "20B2AA", "FFDE5A", "BB6C8A", "FF9900", "A0522D", "6495ED", "6C4675",
            "FFCBDB", "6699CC", "D1E231", "18A7B5", "44944A", "9932CC", "3B83BD", "D8A903", "FF8C00", "177245",
            "4F7942", "DE4C8A", "EA7500", "4285B4", "03C03C", "2E8B57", "EDFF21", "A47C45", "3F888F", "89AC76",
            "008B8B", "A8E4A0", "5DA130", "C1876B", "A03472", "CC0605", "C4A43D", "434B1B", "B55489", "4D7198",
            "834D18", "008CF0", "E32636", "FFCC00", "CA3A27", "F4C800", "93AA00", "FF6800", "9966CC", "D5265B",
            "990066", "425E17", "00836E", "FFB02E", "D2691E", "E3256B", "008080", "3E5F8A", "FF7514", "30BA8F",
        };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strColor = value.ToString();
            if (string.IsNullOrEmpty(strColor)) return Application.Current.Resources["MainColor"];

            try
            {
                string hash = System.Convert.ToInt32(strColor[0]).ToString();
                if (hash.Length < 2) hash = hash.Insert(0, "0");
                int index = int.Parse(hash.Substring(hash.Length - 2, 2));
                var color = Color.FromHex(_colors[index]);
                return color;
            }
            catch { }
            return Application.Current.Resources["MainColor"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
