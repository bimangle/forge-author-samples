using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bimangle.ForgeAuthor.Differ
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var clientId = Properties.Settings.Default.ClientId;
            if (string.IsNullOrWhiteSpace(clientId) == false)
            {
                LicenseService.Activate(clientId, @"Differ");
            }

            Application.Run(new FormApp());
        }
    }
}
