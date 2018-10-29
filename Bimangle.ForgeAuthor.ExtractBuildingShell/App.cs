using System.Windows.Forms;

namespace Bimangle.ForgeAuthor.ExtractBuildingShell
{
    static class App
    {
        public const string PRODUCT_NAME = @"ConvertSvfToGltf";

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
