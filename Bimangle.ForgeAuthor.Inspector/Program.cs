using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bimangle.ForgeAuthor.Svf;

namespace Bimangle.ForgeAuthor.Inspector
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string filePath;

            if (args.Length > 0)
            {
                filePath = Path.GetFullPath(args[0]);
            }
            else
            {
                var dialog = new OpenFileDialog();
                dialog.CheckPathExists = true;
                dialog.Title = @"Select Svf Model File";
                dialog.Filter = @"Autodesk Forge 3D Model|*.svf;*.svfzip|All Files|*.*";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() != DialogResult.OK) return;

                filePath = dialog.FileName;
            }

            try
            {
                using (new ProgressHelper(null, @"Loading ..."))
                {
                    using (var svfDb = SvfDatabase.LoadFrom(filePath))
                    {
                        Application.Run(new FormApp(svfDb, filePath));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
