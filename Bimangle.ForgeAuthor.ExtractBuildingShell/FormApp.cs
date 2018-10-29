using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Bimangle.ForgeAuthor.Extension.Gltf;
using Bimangle.ForgeAuthor.Svf;
using Bimangle.ForgeEngine.Common.Utils;

namespace Bimangle.ForgeAuthor.ExtractBuildingShell
{
    partial class FormApp : Form
    {
        private string _ExtractShellCLI;

        public FormApp()
        {
            InitializeComponent();
        }

        private void FormApp_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.app;
            Text += @" v" + PackageInfo.ProductVersion;

            _ExtractShellCLI = @"C:\ProgramData\Bimangle\Bimangle.ForgeEngine.Revit\Tools\ExtractShell\ExtractShellCLI.exe";

            RefreshState();
        }

        private void licenseStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowLicenseDialog(this);
        }

        private void githubSourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/bimangle/forge-author-samples");
        }

        private void aboutForgeAuthorMergerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, @"This software is one of samples for use Bimangle.ForgeAuthor SDK.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBrowseBaseModel_Click(object sender, EventArgs e)
        {
            if (dlgSelectFile.ShowDialog(this) == DialogResult.OK)
            {
                txtInputFilePath.Text = dlgSelectFile.FileName;
            }
        }

        private void btnBrowseDiffModel_Click(object sender, EventArgs e)
        {
            if (dlgSelectFolder.ShowDialog(this) == DialogResult.OK)
            {
                txtOutputFilePath.Text = dlgSelectFolder.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (var session = App.CreateSession())
            {
                if (session.IsValid == false)
                {
                    LicenseSession.ShowLicenseDialog(session, this);
                    return;
                }

                if (File.Exists(_ExtractShellCLI) == false)
                {
                    MessageBox.Show(this, @"ExtractShellCLI.exe doesn't existed!", Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                using (new ProgressHelper(this, @"Extract Building's Shell ..."))
                {
                    try
                    {
                        var sw = Stopwatch.StartNew();

                        var inputFilePath = txtInputFilePath.Text;
                        var outputFolderPath = txtOutputFilePath.Text;

                        Extract(inputFilePath, outputFolderPath, CancellationToken.None);

                        ProgressHelper.Close();
                        var message = $@"Extract Model Success! (duration: {sw.Elapsed})";
                        MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        ProgressHelper.Close();
                        MessageBox.Show(this, ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtBaseModel_TextChanged(object sender, EventArgs e)
        {
            RefreshState();
        }

        private void txtDiffModel_TextChanged(object sender, EventArgs e)
        {
            RefreshState();
        }

        private void RefreshState()
        {
            btnGenerate.Enabled = CheckValid();
        }

        private bool CheckValid()
        {
            if (string.IsNullOrEmpty(txtInputFilePath.Text) || File.Exists(txtInputFilePath.Text) == false)
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtOutputFilePath.Text) || Directory.Exists(txtOutputFilePath.Text) == false)
            {
                return false;
            }

            return true;
        }


        private void Extract(string inputFilePath, string outputFolderPath, CancellationToken token)
        {
            using (var fc = new FileCleaner())
            {
                var idsFilePath = Path.GetTempFileName();
                fc.AddFile(idsFilePath);

                if (token.IsCancellationRequested) return;
                if (ExtractShell(_ExtractShellCLI, inputFilePath, idsFilePath, token))
                {
                    //如果抽壳成功，则从原始模型中把外壳提取出来另存
                    if (token.IsCancellationRequested) return;
                    using (var doc = SvfDocument.LoadFrom(inputFilePath))
                    {
                        if (token.IsCancellationRequested) return;
                        doc.Extract(idsFilePath, outputFolderPath, token);
                    }

                }
            }
        }


        /// <summary>
        /// 抽取模型外壳
        /// </summary>
        /// <param name="cliFilePath">ExtractShellCLI.exe 的路径</param>
        /// <param name="inputFilePath">输入的SVF文件路径</param>
        /// <param name="outputFilePath">输出的IDS文件路径</param>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool ExtractShell(string cliFilePath, string inputFilePath, string outputFilePath, CancellationToken token)
        {
            try
            {
                if (File.Exists(cliFilePath) == false)
                {
                    throw new FileNotFoundException(@"ExtractShellCLI Missing!", cliFilePath);
                }

                if (File.Exists(inputFilePath) == false &&
                    Directory.Exists(inputFilePath) == false)
                {
                    throw new FileNotFoundException(@"Input File Missing!", inputFilePath);
                }

                var arguments = CommandLineArguments.Create(
                    @"-i", inputFilePath,
                    @"-o", outputFilePath);
                var startinfo = new ProcessStartInfo(cliFilePath, arguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };

                if (token.IsCancellationRequested) return false;
                var process = Process.Start(startinfo);
                if (process == null)
                {
                    Trace.WriteLine(@"ExtractShellCLI Launch Fail!");
                    return false;
                }

                using (process)
                {
#if DEBUG
                    process.BeginErrorReadLine();
                    process.BeginOutputReadLine();

                    process.OutputDataReceived += (sender, args) =>
                    {
                        if (args.Data != null) Trace.WriteLine(args.Data);
                    };
                    process.ErrorDataReceived += (sender, args) =>
                    {
                        if (args.Data != null) Trace.WriteLine(@"Error: " + args.Data);
                    };
#endif

                    while (process.WaitForExit(1000) == false && token.IsCancellationRequested == false)
                    {
                        Application.DoEvents();
                    }

                    if (token.IsCancellationRequested)
                    {
                        process.Kill();
                        return false;
                    }

                    var code = process.ExitCode;
                    if (code == 0) return true;

                    Trace.WriteLine($@"ExtractShellCLI ExitCode: {code}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return false;
            }
        }

    }
}
