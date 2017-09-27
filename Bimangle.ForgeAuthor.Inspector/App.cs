using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bimangle.ForgeAuthor.Inspector
{
    static class App
    {
        public const string PRODUCT_NAME = @"Inspector";

        public static string GetClientId()
        {
            var clientId = Properties.Settings.Default.ClientId;
            if (string.IsNullOrWhiteSpace(clientId))
            {
                clientId = @"BimAngle";
            }
            return clientId;
        }


        public static LicenseSession CreateSession()
        {
            return new LicenseSession(GetClientId(), PRODUCT_NAME);
        }

        public static void ShowLicenseDialog(IWin32Window parent = null)
        {
            LicenseSession.ShowLicenseDialog(GetClientId(), PRODUCT_NAME, parent);
        }
    }
}
