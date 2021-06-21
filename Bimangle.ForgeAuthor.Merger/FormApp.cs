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
using Bimangle.ForgeAuthor.Merger.Utility;
using Bimangle.ForgeAuthor.Svf;
using Bimangle.ForgeBrowser.Author.Merger.Types;
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

            cbPositioningMode.Items.Clear();
            cbPositioningMode.Items.Add(new ItemValue<PositioningMode>(PositioningMode.BySharedCoordinates, @"Auto - By Shared Coordinates"));
            cbPositioningMode.Items.Add(new ItemValue<PositioningMode>(PositioningMode.OriginToOrigin, @"Auto - Origin to Origin"));
            cbPositioningMode.Items.Add(new ItemValue<PositioningMode>(PositioningMode.ProjectBasePointToProjectBasePoint, @"Auto - Project Base Point to Project Base Point"));
            cbPositioningMode.Items.Add(new ItemValue<PositioningMode>(PositioningMode.CenterToCenter, @"Auto - Center to Center"));
            cbPositioningMode.SelectedIndex = 0;

            dgvSourceModels.EnableFilePathDrop(AddInputModel);

            txtOutput.EnableFolderPathDrop();
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
            LicenseConfig.ShowDialog(this);
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

            var mode = (int)((cbPositioningMode.SelectedItem as ItemValue<PositioningMode>)?.Value ?? PositioningMode.BySharedCoordinates);

            using (var session = LicenseConfig.Create())
            {
                if (session.IsValid == false)
                {
                    LicenseConfig.ShowDialog(session, this);
                    return;
                }

                using (new ProgressHelper(this, @"Merging ..."))
                {
                    try
                    {
                        var sw = Stopwatch.StartNew();
                        SvfDocument targetDoc = null;
                        Transform targetTransform = null;

                        var docs = new List<SvfDocument>();
                        foreach (var model in models)
                        {
                            var doc = model.ModelPath.EndsWith(@"zip")
                                ? SvfDocument.LoadFromZipFile(model.ModelPath)
                                : SvfDocument.LoadFromSvfFile(model.ModelPath);
                            doc.Model.Name = model.ModelTitle;

                            if (targetDoc == null)
                            {
                                targetDoc = CreateTarget(doc, mode, out targetTransform);
                            }

                            if (targetDoc.Metadata.DefaultCamera == null && doc.Metadata.DefaultCamera != null)
                            {
                                targetDoc.Metadata.DefaultCamera = doc.Metadata.DefaultCamera.Clone();
                            }

                            var transform = targetTransform
                                .Clone()
                                .Multiply(Metadata.GetUnitScaleTransform(doc.Metadata.Units, targetDoc.Metadata.Units));    //计量单位的转换
                            switch (mode)
                            {
                                case 1: //原点对原点
                                {
                                    break;
                                }
                                case 2: //项目基点对项目基点
                                {
                                    transform = transform.Multiply(doc.Metadata.PrjPointTransform);
                                    break;
                                }
                                case 3: //中心对中心
                                {
                                    var box = doc.Metadata.WorldBoundingBox;
                                    if (box != null && !box.IsEmpty())
                                    {
                                        var offset = new Vector3D();
                                        offset.X = -(box.Max.X + box.Min.X) / 2;
                                        offset.Y = -(box.Max.Y + box.Min.Y) / 2;
                                        offset.Z = -(box.Max.Z + box.Min.Z) / 2;
                                        var translation = Transform.GetTranslation(offset);
                                        transform = transform.Multiply(translation);
                                    }
                                    break;
                                }
                                case 0: //通过共享坐标
                                default:
                                {
                                    transform = transform.Multiply(doc.Metadata.RefPointTransform);
                                    break;
                                }
                            }

                            targetDoc.Model.Children.ImportNode(doc.Model, transform);

                            doc.Reset();
                            docs.Add(doc);
                        }

                        if (targetDoc.Metadata.DefaultCamera != null) targetDoc.Metadata.DefaultCamera.AutoFit = true;

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

        private SvfDocument CreateTarget(SvfDocument initDoc, int mode, out Transform targetTransform)
        {
            targetTransform = Transform.GetIdentity();

            var doc = new SvfDocument();
            var meta = doc.Metadata = initDoc.Metadata.Clone(true);

            #region 整理转换矩阵元数据

            if (meta.RefPointTransform == null)
            {
                if (meta.RefPointLMV != null && meta.AngleToTrueNorth.HasValue)
                {
                    var angle = meta.AngleToTrueNorth.Value * Math.PI / 180.0;
                    var rotation = new QuaternionD().SetFromEuler(new EulerD(0.0, 0.0, angle));
                    meta.RefPointTransform = Transform.GetRotationTranslation(rotation, meta.RefPointLMV);
                }
                else
                {
                    meta.RefPointTransform = Transform.GetIdentity();
                }
            }
            if (meta.PrjPointTransform == null)
            {
                meta.PrjPointTransform = Transform.GetIdentity();
            }

            #endregion

            switch (mode)
            {
                case 1: //原点对原点
                    {
                        //合模时使用原始内部坐标系，直接使用即可;
                        break;
                    }
                case 2: //项目基点对项目基点
                    {
                        //合模时使用项目坐标系，最后结果需要转换为内部坐标系
                        targetTransform = meta.PrjPointTransform.Inverse() ?? Transform.GetIdentity();
                        break;
                    }
                case 3: //中心对中心
                    {
                        //合模时使用内部坐标系，但因为原点做了偏移，最后结果需要修正回来;
                        var box = doc.Metadata.WorldBoundingBox;
                        if (box != null && !box.IsEmpty())
                        {
                            var offset = new Vector3D();
                            offset.X = -(box.Max.X + box.Min.X) / 2;
                            offset.Y = -(box.Max.Y + box.Min.Y) / 2;
                            offset.Z = -(box.Max.Z + box.Min.Z) / 2;
                            targetTransform = Transform.GetTranslation(offset.MultiplyScalar(-1));
                        }
                        break;
                    }
                case 0: //通过共享坐标
                default:
                    {
                        //合模时使用共享坐标系，最后结果需要转换为内部坐标系
                        targetTransform = meta.RefPointTransform.Inverse() ?? Transform.GetIdentity();
                        break;
                    }
            }

            return doc;
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

        private class ItemValue<T>
        {
            public T Value { get; }
            public string Text { get; }

            public ItemValue(T value, string text)
            {
                Value = value;
                Text = text;
            }

            #region Overrides of Object

            public override string ToString()
            {
                return Text;
            }

            #endregion
        }

    }
}
