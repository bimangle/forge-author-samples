using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bimangle.ForgeAuthor.Merger.Types;
using Bimangle.ForgeAuthor.Svf;
using Bimangle.ForgeEngine.Types.Geometry;
using Bimangle.ForgeEngine.Types.Misc;

namespace Bimangle.ForgeAuthor.Merger
{
    partial class FormApp : Form
    {
        public FormApp()
        {
            InitializeComponent();
        }

        private void FormApp_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.app;
            Text += @" v" + PackageInfo.ProductVersion;

#if DEBUG
            //for test 
            //AddInputModel(@"E:\Temp\2018-08-01\hemo\f1\3d.svf");
            //AddInputModel(@"E:\Temp\2018-08-01\hemo\f2\3d.svf");
            //txtOutput.Text = @"E:\Temp\2018-08-01\output";
#endif
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOutput.Text) == false)
            {
                dlgSelectFolder.SelectedPath = txtOutput.Text;
            }

            if (dlgSelectFolder.ShowDialog(this) == DialogResult.OK)
            {
                txtOutput.Text = dlgSelectFolder.SelectedPath;
            }
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
            MessageBox.Show(this, @"This software is one of samples for use Bimangle.ForgeAuthor SDK.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dlgSelectFile.ShowDialog(this) == DialogResult.OK)
            {
                foreach (var filePath in dlgSelectFile.FileNames)
                {
                    AddInputModel(filePath);
                }
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            var models = new List<SvfModel>();
            foreach (SvfModel item in svfModelBindingSource)
            {
                if (item == null) continue;
                models.Add(item);
            }
            if (models.Count < 1)
            {
                MessageBox.Show(this, @"The source model list is empty!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtOutput.Text))
            {
                MessageBox.Show(this, @"Please Select Output Path!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var session = App.CreateSession())
            {
                if (session.IsValid == false)
                {
                    LicenseSession.ShowLicenseDialog(session, this);
                    return;
                }

                using (new ProgressHelper(this, @"Merging ..."))
                {
                    try
                    {
                        var sw = Stopwatch.StartNew();
                        var targetDoc = new SvfDocument();
                        var docs = new List<SvfDocument>();
                        var init = false;
                        foreach (var model in models)
                        {
                            var doc = model.ModelPath.EndsWith(@"zip")
                                ? SvfDocument.LoadFromZipFile(model.ModelPath)
                                : SvfDocument.LoadFromSvfFile(model.ModelPath);
                            doc.Model.Name = model.ModelTitle;

                            if (!init)
                            {
                                targetDoc.Metadata = doc.Metadata.Clone();
                                init = true;
                            }

                            if (targetDoc.Metadata.DefaultCamera == null && doc.Metadata.DefaultCamera != null)
                            {
                                targetDoc.Metadata.DefaultCamera = doc.Metadata.DefaultCamera.Clone();
                            }

                            var transform = Metadata
                                .GetUnitScaleTransform(doc.Metadata.Units, targetDoc.Metadata.Units)
                                .Multiply(doc.Metadata.RefPointTransform);

                            targetDoc.Model.Children.ImportNode(doc.Model, transform);

                            doc.Reset();
                            docs.Add(doc);
                        }

                        targetDoc.SaveToFolder(txtOutput.Text, true);
                        targetDoc.Dispose();

                        foreach (var doc in docs)
                        {
                            doc.Dispose();
                        }
                        docs.Clear();

                        ProgressHelper.Close();
                        var message = $@"Merge Success! (duration: {sw.Elapsed})";
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

        private void AddInputModel(string filePath)
        {
            var svfModel = new SvfModel
            {
                ModelTitle = $@"Model {svfModelBindingSource.Count + 1}#",
                ModelPath = filePath
            };
            if (svfModel.ModelPath.EndsWith(@"zip"))
            {
                svfModel.ModelTitle = Path.GetFileNameWithoutExtension(svfModel.ModelPath);
            }

            foreach (SvfModel item in svfModelBindingSource)
            {
                if (item == null) continue;
                if (item.ModelPath == svfModel.ModelPath)
                {
                    MessageBox.Show(this, @"This model already add to list!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            svfModelBindingSource.Add(svfModel);
        }

    }
}
