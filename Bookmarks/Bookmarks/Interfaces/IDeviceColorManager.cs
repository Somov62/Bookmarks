namespace Bookmarks.Interfaces
{
    public interface IDeviceColorManager
    {
        void SetNavBarColor(string hex);

        void SetStatusBarColor(string hex);
        void SetTitleColor(string hex);
    }
}
