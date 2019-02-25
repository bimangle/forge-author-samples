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
using Bimangle.ForgeAuthor.Svf;
using Bimangle.ForgeAuthor.Svf.Types;
using Bimangle.ForgeEngine.Types.Geometry;
using Bimangle.ForgeEngine.Types.Misc;

namespace Bimangle.ForgeAuthor.Differ
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
            //compare mesh's surface area, instead of primitives
            SvfDocument.EnabledAdvancedMeshCompare = true;

            this.txtBaseModel.Text = @"E:\Temp\2018-08-29\n1.svfzip";
            this.txtIncrementModel.Text = @"E:\Temp\2018-08-29\n2.svfzip";
            this.txtDiffModel.Text = @"E:\Temp\2018-08-29\diff2";
#endif

            RefreshState();
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
            MessageBox.Show(this, @"This software is one of samples for use Bimangle.ForgeAuthor SDK.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBrowseBaseModel_Click(object sender, EventArgs e)
        {
            if (dlgSelectFile.ShowDialog(this) == DialogResult.OK)
            {
                txtBaseModel.Text = dlgSelectFile.FileName;
            }
        }

        private void btnBrowseIncrementModel_Click(object sender, EventArgs e)
        {
            if (dlgSelectFile.ShowDialog(this) == DialogResult.OK)
            {
                txtIncrementModel.Text = dlgSelectFile.FileName;
            }
        }

        private void btnBrowseDiffModel_Click(object sender, EventArgs e)
        {
            if (dlgSelectFolder.ShowDialog(this) == DialogResult.OK)
            {
                txtDiffModel.Text = dlgSelectFolder.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (var session = LicenseConfig.Create())
            {
                if (session.IsValid == false)
                {
                    LicenseConfig.ShowDialog(session, this);
                    return;
                }

                using (new ProgressHelper(this, @"Generating Diff Model ..."))
                {
                    try
                    {
                        var sw = Stopwatch.StartNew();

                        #region setup materials

                        var matUnmodified = new Material
                        {
                            Color = Vector3D.FromColor(0xffffff), //Darker: Vector3D.FromColor(0x101010)
                            Transparent = 0.95,
                            Reflectivity = 0
                        };

                        var matAdd = new Material
                        {
                            Color = Vector3D.FromColor(Color.GreenYellow)
                        };

                        var matDelete = new Material
                        {
                            Color = Vector3D.FromColor(Color.Red)
                        };

                        var matModifiedBefore = new Material
                        {
                            Color = Vector3D.FromColor(Color.Orange),
                            Transparent = 0.5
                        };

                        var matModifiedAfter = new Material
                        {
                            Color = Vector3D.FromColor(Color.Aqua),
                        };

                        #endregion

                        var baseModelPath = txtBaseModel.Text;
                        var incrModelPath = txtIncrementModel.Text;
                        var diffModelPath = txtDiffModel.Text;

                        var svfbase = baseModelPath.EndsWith(@"zip")
                            ? SvfDocument.LoadFromZipFile(baseModelPath)
                            : SvfDocument.LoadFromSvfFile(baseModelPath);

                        var svfincr = incrModelPath.EndsWith(@"zip")
                            ? SvfDocument.LoadFromZipFile(incrModelPath)
                            : SvfDocument.LoadFromSvfFile(incrModelPath);

                        var compareResult = CompareModel(svfbase, svfincr);

                        var svfdiff = new SvfDocument();
                        svfdiff.Model.Name = @"Diff Model";
                        svfdiff.Metadata = svfbase.Metadata;

                        var nodeUnmodified = svfdiff.Model.Children.CreateNode();
                        nodeUnmodified.Name = @"Unmodified";

                        var nodeAdded = svfdiff.Model.Children.CreateNode();
                        nodeAdded.Name = @"Added";

                        var nodeDeleted = svfdiff.Model.Children.CreateNode();
                        nodeDeleted.Name = @"Deleted";

                        var nodeModifiedBefore = svfdiff.Model.Children.CreateNode();
                        nodeModifiedBefore.Name = @"Modified Before";

                        var nodeModifiedAfter = svfdiff.Model.Children.CreateNode();
                        nodeModifiedAfter.Name = @"Modified After";

                        foreach(var node in svfbase)
                        {
                            if (node.Children?.Count == 0 &&
                                node.Fragments?.Count > 0 &&
                                string.IsNullOrEmpty(node.ExternalId) == false)
                            {
                                if (compareResult.Unmodified.Remove(node.ExternalId))
                                {
                                    ImportNodeWithPath(nodeUnmodified, node, svfbase.Model, matUnmodified);
                                }
                                else if (compareResult.Deleted.Remove(node.ExternalId))
                                {
                                    ImportNodeWithPath(nodeDeleted, node, svfbase.Model, matDelete);
                                }
                                else if (compareResult.Modified.Contains(node.ExternalId))
                                {
                                    var targetNode =
                                        ImportNodeWithPath(nodeModifiedBefore, node, svfbase.Model, matModifiedBefore);
                                    targetNode.ExternalId += @"_Before";
                                }
                            }
                        }

                        foreach(var node in svfincr)
                        {
                            if (node.Children?.Count == 0 &&
                                node.Fragments?.Count > 0 &&
                                string.IsNullOrEmpty(node.ExternalId) == false)
                            {
                                if (compareResult.Added.Remove(node.ExternalId))
                                {
                                    ImportNodeWithPath(nodeAdded, node, svfincr.Model, matAdd);
                                }
                                else if (compareResult.Modified.Remove(node.ExternalId))
                                {
                                    ImportNodeWithPath(nodeModifiedAfter, node, svfincr.Model, matModifiedAfter);
                                }
                            }
                        }

                        svfdiff.SaveToFolder(diffModelPath, true);
                        svfdiff.Dispose();

                        svfbase.Dispose();
                        svfincr.Dispose();

                        ProgressHelper.Close();
                        var message = $@"Generate Diff Model Success! (duration: {sw.Elapsed})";
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

        private void txtIncrementModel_TextChanged(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(txtBaseModel.Text) || File.Exists(txtBaseModel.Text) == false)
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtIncrementModel.Text) || File.Exists(txtIncrementModel.Text) == false)
            {
                return false;
            }

            if (txtBaseModel.Text == txtIncrementModel.Text)
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtDiffModel.Text) || Directory.Exists(txtDiffModel.Text) == false)
            {
                return false;
            }

            return true;
        }

        private (HashSet<string> Unmodified, HashSet<string> Added, HashSet<string> Deleted, HashSet<string> Modified)
            CompareModel(SvfDocument svfbase, SvfDocument svfincr)
        {
            var baseNodes = new Dictionary<string, SvfNode>();
            foreach(var node in svfbase)
            {
                if (node.Children?.Count == 0
                    && node.Fragments?.Count > 0
                    && string.IsNullOrEmpty(node.ExternalId) == false)
                {
                    baseNodes[node.ExternalId] = node;
                }
            }

            var elementsAdded = new HashSet<string>();
            var elementsUnmodified = new HashSet<string>();
            var elementsModified = new HashSet<string>();
            var elementsDeleted = new HashSet<string>();

            foreach(var node in svfincr)
            {
                if (node.Children?.Count == 0
                    && node.Fragments?.Count > 0
                    && string.IsNullOrEmpty(node.ExternalId) == false)
                {
                    if (baseNodes.TryGetValue(node.ExternalId, out SvfNode baseNode))
                    {
                        if (baseNode.Fragments.Equals(node.Fragments))
                        {
                            elementsUnmodified.Add(node.ExternalId); //unmdified
                        }
                        else
                        {
                            elementsModified.Add(node.ExternalId); //modified
                        }

                        baseNodes.Remove(node.ExternalId);
                    }
                    else
                    {
                        elementsAdded.Add(node.ExternalId); //added
                    }
                }
            }

            foreach (var p in baseNodes.Keys)
            {
                elementsDeleted.Add(p); //deleted
            }
            baseNodes.Clear();

            return (elementsUnmodified, elementsAdded, elementsDeleted, elementsModified);
        }

        private SvfNode ImportNodeWithPath(SvfNode targetNodeRoot, SvfNode sourceNode, SvfNode sourceNodeRoot, Material material)
        {
            var targetNode = sourceNode.Parent == sourceNodeRoot
                ? targetNodeRoot
                : ImportNodeWithPath(targetNodeRoot, sourceNode.Parent, sourceNodeRoot, material);
            var resultNode = targetNode.Children.FirstOrDefault(x => x.Name == sourceNode.Name);
            if (resultNode == null)
            {
                resultNode = targetNode.Children.ImportNode(sourceNode, null, false);
                foreach (var fragment in resultNode.Fragments)
                {
                    fragment.Material = material;
                }
            }
            return resultNode;
        }
    }
}
