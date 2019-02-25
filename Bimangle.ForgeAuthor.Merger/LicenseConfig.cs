using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Bimangle.ForgeAuthor.Merger
{
    static class LicenseConfig
    {

#if DEBUG
        public const string LICENSE_KEY = null;
#else
        public const string LICENSE_KEY = null;
#endif

        public const string CLIENT_ID = @"BimAngle";

        public const string PRODUCT_NAME = @"Merger";

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static LicenseSession Create()
        {
            LicenseSession.Init();
            return new LicenseSession(CLIENT_ID, PRODUCT_NAME, LICENSE_KEY);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ShowDialog(LicenseSession session, IWin32Window parent)
        {
            var info = LicenseSession.GetLicenseInfo(CLIENT_ID, PRODUCT_NAME, LICENSE_KEY);

            LicenseSession.ShowLicenseDialog(session.ClientId, session.AppName, parent);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ShowDialog(IWin32Window parent)
        {
            var info = LicenseSession.GetLicenseInfo(CLIENT_ID, PRODUCT_NAME, LICENSE_KEY);

            LicenseSession.ShowLicenseDialog(CLIENT_ID, PRODUCT_NAME, parent);
        }
    }
}
