using Xamarin.Forms;
using Bookmarks.Interfaces;
using Java.Lang;

[assembly: Dependency(typeof(Bookmarks.Droid.DeviceRootAccess))]

namespace Bookmarks.Droid
{
    public class DeviceRootAccess : IDeviceRootAccess
    {
        public bool CheckRootAccess()
        {
            bool retval;
            try
            {
                Process suProcess = Runtime.GetRuntime().Exec("su");
                var outputStream = new Java.IO.DataOutputStream(suProcess.OutputStream);
                var responseStream = new Java.IO.DataInputStream(suProcess.InputStream);

                if (outputStream == null || responseStream == null) return false;

                outputStream.WriteBytes("id\n");
                outputStream.Flush();

                string currUid = responseStream.ReadLine();

                if (currUid == null) return false;

                if (currUid.Contains("uid=0"))
                    retval = true;

                else 
                    retval = false;

                outputStream.WriteBytes("exit\n");
                outputStream.Flush();

            }
            catch (Java.Lang.Exception e)
            {
                retval = false;
            }

            return retval;
        }
    }
}