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
using Bimangle.ForgeAuthor.Svf.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bimangle.ForgeAuthor.Inspector
{
    public partial class FormApp : Form
    {
        private string _SvfFilePath;
        private SvfDatabase _SvfDb;

        private SvfNode _CurrentSvfNode;
        private TreeNode _CurrentTreeNode;

        public FormApp()
        {
            InitializeComponent();
        }

        public FormApp(SvfDatabase svfDb, string svfFilePath) : this()
        {
            _SvfDb = svfDb ?? throw new ArgumentNullException(nameof(svfDb));
            _SvfFilePath = svfFilePath ?? throw new ArgumentNullException(nameof(svfFilePath));
        }

        private void FormApp_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.app;
            Text = $@"{_SvfFilePath} - {Text} v1.0";

            tvModel.Nodes.Clear();
            var treeNode = LoadNode(tvModel.Nodes, _SvfDb, _SvfDb.Model, 0);
            treeNode?.Expand();
        }

        private void FormApp_Shown(object sender, EventArgs e)
        {
            ProgressHelper.Close();
        }

        private void tvModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _CurrentTreeNode = tvModel.SelectedNode;
            _CurrentSvfNode = _CurrentTreeNode?.Tag as SvfNode;
            if (_CurrentSvfNode == null) return;

            lblDbId.Text = _CurrentSvfNode.Id.ToString();
            txtName.Text = _CurrentSvfNode.Name ?? @"<null>";
            txtCategory.Text = _CurrentSvfNode.Category ?? @"<null>";
            txtExternalId.Text = _CurrentSvfNode.ExternalId ?? @"<null>";

            pgNodeProperties.SelectedObject = new SvfNodePropertyGridAdapter(tvModel.SelectedNode.Tag as SvfNode);

        }

        private TreeNode LoadNode(TreeNodeCollection treeNodes, SvfDatabase reader, SvfNode propNode, int depth)
        {
            //var treeNode = new TreeNode($"([{nodeId}]{propNode.Category}) {propNode.Name}");
            var treeNode = new TreeNode($"{propNode.Name}");
            treeNode.Tag = propNode;

            foreach (var childNode in propNode.Children)
            {
                LoadNode(treeNode.Nodes, reader, childNode, depth++);
            }

            treeNodes.Add(treeNode);

            return treeNode;
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (new ProgressHelper("Saving ..."))
                {
                    _SvfDb.Save();
                }

                MessageBox.Show(this, @"Save Success!", Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text);
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (_CurrentTreeNode != null && _CurrentTreeNode.Name != txtName.Text)
            {
                _CurrentTreeNode.Text = txtName.Text;
            }

            if (_CurrentSvfNode != null && _CurrentSvfNode.Name != txtName.Text)
            {
                _CurrentSvfNode.Name = txtName.Text;
            }

        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            if (_CurrentSvfNode != null && _CurrentSvfNode.Name != txtCategory.Text)
            {
                _CurrentSvfNode.Category = txtCategory.Text;
            }
        }

        private void txtExternalId_TextChanged(object sender, EventArgs e)
        {
            if (_CurrentSvfNode != null && _CurrentSvfNode.ExternalId != txtExternalId.Text)
            {
                _CurrentSvfNode.ExternalId = txtExternalId.Text;
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, @"This software is one of samples for use Bimangle.ForgeAuthor SDK.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmiLicenseStatus_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"Bimangle.ForgeAuthor SDK License Status:");
            sb.AppendLine($@"ReleaseDate:  {PackageInfo.ReleaseDate:yyyy-MM-dd}");
            sb.AppendLine($@"Subscription: {LicenseService.SubscriptionExpiration:yyyy-MM-dd}");
            sb.AppendLine($@"IsActivated:       {LicenseService.IsActivated}");
            sb.AppendLine($@"LicenseStatus:     {LicenseService.LicenseStatus}");
            sb.AppendLine($@"LicenseExpiration: {LicenseService.LicenseExpiration:yyyy-MM-dd}");
            sb.AppendLine($@"HardwareId:   {LicenseService.HardwareId}");
            sb.AppendLine($@"ClientName:   {LicenseService.ClientName}");

            MessageBox.Show(this, sb.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmiExportJson_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdExportToJson.ShowDialog(this) != DialogResult.OK) return;
                var filePath = sfdExportToJson.FileName;

                using (new ProgressHelper("Exporting ..."))
                {
                    var data = new JArray();
                    foreach (var node in _SvfDb)
                    {
                        var info = new JObject();
                        info["id"] = node.Id;
                        info["name"] = node.Name;
                        info["category"] = node.Category;
                        info["externalId"] = node.ExternalId;
                        info["parent"] = node.Parent?.Id ?? -1;

                        var propertyList = new JArray();
                        foreach (var p in node.Properties)
                        {
                            if (p == null) continue;
                            var property = new JArray
                            {
                                p.Def.Category,
                                p.Def.Name,
                                p.AsString(),
                                p.Def.Unit
                            };
                            propertyList.Add(property);
                        }

                        info["props"] = propertyList;

                        data.Add(info);
                    }

                    File.WriteAllText(filePath, data.ToString(Formatting.Indented), Encoding.UTF8);
                }

                MessageBox.Show(this, @"Export Success!", Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text);
            }

        }

        private void tsmiGithub_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/bimangle/forge-author-samples");
        }
    }
}
