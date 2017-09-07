using System;
using System.IO;
using System.Windows.Forms;

namespace Bimangle.ForgeAuthor.Merger
{
    /// <summary>
    /// 授权会话
    /// </summary>
    class LicenseSession : IDisposable
    {
        public const string PRODUCT_NAME = @"Merger";

        public static string GetClientId()
        {
            var clientId = Properties.Settings.Default.ClientId;
            if (string.IsNullOrWhiteSpace(clientId))
            {
                clientId = @"BimAngle";
            }
            return clientId;
        }

        /// <summary>
        /// 打开授权信息窗口
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static bool ShowLicenseDialog(IWin32Window owner = null)
        {
            var form = new FormLicense();
            return form.ShowDialog(owner) == DialogResult.OK;
        }

        /// <summary>
        /// 部署授权文件
        /// </summary>
        /// <param name="buffer"></param>
        public static void DeployLicenseFile(byte[] buffer)
        {
            const string LIC_FILE_NAME = @"Bimangle.ForgeAuthor.lic";
            var dllFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var licFilePath = Path.Combine(dllFolder, LIC_FILE_NAME);
            File.WriteAllBytes(licFilePath, buffer);
        }

        public bool IsValid { get;}

        public LicenseSession(string licenseKey = null) 
            : this(GetClientId(), PRODUCT_NAME, licenseKey)
        {
        }

        public LicenseSession(string clientId, string appName, string licenseKey = null)
        {
            LicenseService.Activate(clientId, appName, licenseKey);
            IsValid = LicenseService.IsActivated;
        }

        #region IDisposable 成员

        void IDisposable.Dispose()
        {
            LicenseService.Deactivate();
        }

        #endregion
    }
}
