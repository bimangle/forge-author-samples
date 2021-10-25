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
    partial class FormApp : Form
    {
        private readonly string _SvfFilePath;
        private SvfDatabase _SvfDb;

        private SvfNode _CurrentSvfNode;
        private TreeNode _CurrentTreeNode;

        private readonly Dictionary<int, TreeNode> _TreeNodes = new Dictionary<int, TreeNode>();

        public FormApp()
        {
            InitializeComponent();
        }

        public FormApp(SvfDatabase svfDb, string svfFilePath) : this()
        {
            _SvfDb = svfDb ?? throw new ArgumentNullException(nameof(svfDb));
            _SvfFilePath = svfFilePath ?? throw new ArgumentNullException(nameof(svfFilePath));
            _CurrentSvfNode = null;
        }

        private void FormApp_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.app;
            Text = $@"{_SvfFilePath} - {Text} v{PackageInfo.ProductVersion}";

            RefreshTree();
        }

        private void FormApp_Shown(object sender, EventArgs e)
        {
            ProgressHelper.Close();
        }

        private void tvModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CurrentTreeNode = tvModel.SelectedNode;
        }

        private void RefreshTree()
        {
            var hideNonGeometryNodes = cbHideNonGeometryNodes.Checked;

            try
            {
                tvModel.BeginUpdate();
                tvModel.Nodes.Clear();

                CurrentTreeNode = null;

                _TreeNodes.Clear();

                var rootTreeNode = LoadTreeNode(tvModel.Nodes, _SvfDb.Model, hideNonGeometryNodes);
                if (CurrentTreeNode == null)
                {
                    rootTreeNode?.Expand();
                }
                else
                {
                    if (tvModel.SelectedNode != CurrentTreeNode)
                    {
                        tvModel.SelectedNode = CurrentTreeNode;
                    }
                    CurrentTreeNode.EnsureVisible();
                }
            }
            finally
            {
                tvModel.EndUpdate();
            }
        }

        private TreeNode LoadTreeNode(TreeNodeCollection treeNodes, SvfNode svfNode, bool hideNonGeometryNodes)
        {
            var treeNode = new TreeNode($"{svfNode.Name}");
            treeNode.Tag = svfNode;

            if (svfNode.ViewableIn)
            {
                treeNode.ForeColor = Color.DarkGreen;
            }

            _TreeNodes[svfNode.Id] = treeNode;

            if (svfNode == _CurrentSvfNode)
            {
                CurrentTreeNode = treeNode;
            }

            foreach (var childNode in svfNode.Children)
            {
                if (hideNonGeometryNodes &&
                    IsGeometryNode(childNode) == false)
                {
                    continue;
                }

                LoadTreeNode(treeNode.Nodes, childNode, hideNonGeometryNodes);
            }

            treeNodes.Add(treeNode);

            return treeNode;
        }

        private bool IsGeometryNode(SvfNode svfNode)
        {
            if (svfNode.ViewableIn) return true;

            if (svfNode.Children != null &&
                svfNode.Children.Count > 0 &&
                svfNode.Children.Any(IsGeometryNode))
            {
                return true;
            }

            return false;
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var session = LicenseConfig.Create())
                {
                    if (session.IsValid == false)
                    {
                        LicenseConfig.ShowDialog(session, this);
                        return;
                    }

                    using (new ProgressHelper(this, "Saving ..."))
                    {
                        _SvfDb.Save();
                    }

                    MessageBox.Show(this, @"Save Success!", Text);
                }
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
            if (CurrentTreeNode != null && CurrentTreeNode.Name != txtName.Text)
            {
                CurrentTreeNode.Text = txtName.Text;
            }

            if (_CurrentSvfNode != null && _CurrentSvfNode.Name != txtName.Text)
            {
                _CurrentSvfNode.Name = txtName.Text;
            }
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            if (_CurrentSvfNode != null && _CurrentSvfNode.Category != txtCategory.Text)
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
            LicenseConfig.ShowDialog(this);
        }

        private void tsmiExportJson_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdExportToJson.ShowDialog(this) != DialogResult.OK) return;
                var filePath = sfdExportToJson.FileName;

                using (new ProgressHelper(this, "Exporting ..."))
                {
                    var data = new JArray();
                    foreach (var node in _SvfDb)
                    {
                        if (node == null) continue;

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

        private TreeNode CurrentTreeNode
        {
            get => _CurrentTreeNode;
            set
            {
                if (_CurrentTreeNode == value) return;
                _CurrentTreeNode = value;

                if (_CurrentTreeNode == null)
                {
                    tvModel.SelectedNode = null;
                    pNodeInfo.Enabled = false;
                }
                else
                {
                    _CurrentTreeNode = value;

                    if (tvModel.SelectedNode != _CurrentTreeNode)
                    {
                        tvModel.SelectedNode = _CurrentTreeNode;

                        _CurrentTreeNode.EnsureVisible();
                    }

                    if (_CurrentTreeNode.Tag != _CurrentSvfNode)
                    {
                        _CurrentSvfNode = (SvfNode)_CurrentTreeNode.Tag;
                        //_Host.SelectNode(_CurrentSvfNode.Id);
                    }

                    {
                        lblDbId.Text = _CurrentSvfNode.Id.ToString();
                        txtName.Text = _CurrentSvfNode.Name ?? @"<null>";
                        txtCategory.Text = _CurrentSvfNode.Category ?? @"<null>";
                        txtExternalId.Text = _CurrentSvfNode.ExternalId ?? @"<null>";

                        pgNodeProperties.SelectedObject = new SvfNodePropertyGridAdapter(_CurrentSvfNode, cbHideInternalProperties.Checked);
                    }

                    pNodeInfo.Enabled = true;
                }
            }
        }
		
		
        private void cbHideNonGeometryNodes_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void cbHideInternalProperties_CheckedChanged(object sender, EventArgs e)
        {
            if (_CurrentSvfNode != null)
            {
                pgNodeProperties.SelectedObject = new SvfNodePropertyGridAdapter(_CurrentSvfNode, cbHideInternalProperties.Checked);
            }
        }

        private void tvModel_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var treeNode = e.Item as TreeNode;
            if (treeNode == null) return;
            if (treeNode.Parent == null) return;    //根节点不可被拖动
            if (treeNode.Tag is SvfNode == false) return;

            CurrentTreeNode = treeNode;

            DoDragDrop(treeNode, DragDropEffects.Move);
        }

        private void tvModel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)) &&
                e.Data.GetData(typeof(TreeNode)) is TreeNode treeNode &&
                treeNode.Tag is SvfNode)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tvModel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)) &&
                e.Data.GetData(typeof(TreeNode)) is TreeNode treeNode &&
                treeNode.Tag is SvfNode svfNode)
            {
                var pos = tvModel.PointToClient(new Point(e.X, e.Y));
                var targetTreeNode = tvModel.GetNodeAt(pos);
                if (targetTreeNode != null &&
                    targetTreeNode != treeNode &&
                    targetTreeNode.Tag is SvfNode targetSvfNode &&
                    targetSvfNode.ViewableIn == false &&         //目标节点不能为几何节点
                    targetSvfNode.IsAncestor(svfNode) == false   //目标节点不能是源节点的子孙节点
                )
                {
                    e.Effect = DragDropEffects.Move;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void tvModel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)) &&
                e.Data.GetData(typeof(TreeNode)) is TreeNode treeNode &&
                treeNode.Tag is SvfNode svfNode)
            {
                
                var pos = tvModel.PointToClient(new Point(e.X, e.Y));
                var targetTreeNode = tvModel.GetNodeAt(pos);
                if (targetTreeNode != null &&
                    targetTreeNode != treeNode &&
                    targetTreeNode.Tag is SvfNode targetSvfNode &&
                    targetSvfNode.ViewableIn == false &&         //目标节点不能为几何节点
                    targetSvfNode.IsAncestor(svfNode) == false   //目标节点不能是源节点的子孙节点
                )
                {
                    if (targetTreeNode == treeNode.Parent)
                    {
                        //如果目标节点已经是源节点的父节点, 则把当前节点移动到子节点队列的最开始位置
                        targetSvfNode.Children.SetChildIndex(svfNode, 0);
                    }
                    else if (targetSvfNode.Parent == svfNode.Parent)
                    {
                        //如果目标节点是源节点的同级节点，则把当前节点移动到子节点队列的后面
                        var sourceIndex = svfNode.Parent.Children.GetChildIndex(svfNode);
                        var targetIndex = svfNode.Parent.Children.GetChildIndex(targetSvfNode);
                        var index = sourceIndex < targetIndex ? targetIndex : targetIndex + 1;
                        targetSvfNode.Parent.Children.SetChildIndex(svfNode, index);
                    }
                    else
                    {
                        //将源节点移入目标节点的子节点
                        targetSvfNode.Children.Enroll(svfNode);
                        targetSvfNode.Children.SetChildIndex(svfNode, 0);
                    }

                    RefreshTree();
                }
            }
        }

        private void tsmiOrderSceneNodes_Click(object sender, EventArgs e)
        {
            _SvfDb.Model.Children.Sort(x=>x.Name, false, true);

            RefreshTree();
        }

        private void tsmiOrderSceneNodesReverse_Click(object sender, EventArgs e)
        {
            _SvfDb.Model.Children.Sort(x => x.Name, true, true);

            RefreshTree();
        }

        private void tsmiReload_Click(object sender, EventArgs e)
        {
            _SvfDb = SvfDatabase.LoadFrom(_SvfFilePath);

            RefreshTree();
        }

        private void tsmiAddNumPrefix_Click(object sender, EventArgs e)
        {
            var numList = new List<int>();
            var num = 1001;

            AddNumPrefix(_SvfDb.Model, numList, num, cbHideNonGeometryNodes.Checked);

            RefreshTree();
        }

        private void AddNumPrefix(SvfNode node, IList<int> numList, int num, bool skipNonGeometryNodes)
        {
            numList.Add(num);

            var numPrefix = string.Join(@".", numList);
            node.Name = $@"({numPrefix}){node.Name}";

            var n = 1;
            foreach (var childNode in node.Children)
            {
                if (skipNonGeometryNodes &&
                    IsGeometryNode(childNode) == false)
                {
                    continue;
                }

                AddNumPrefix(childNode, numList.ToList(), n++, skipNonGeometryNodes);
            }
        }
    }
}
