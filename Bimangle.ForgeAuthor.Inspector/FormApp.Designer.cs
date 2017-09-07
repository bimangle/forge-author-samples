namespace Bimangle.ForgeAuthor.Inspector
{
    partial class FormApp
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvModel = new System.Windows.Forms.TreeView();
            this.pgNodeProperties = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpGeneralInfo = new System.Windows.Forms.GroupBox();
            this.txtExternalId = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDbId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportPropertiesToJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportJson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLicenseStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdExportToJson = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpGeneralInfo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvModel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgNodeProperties);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 586);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvModel
            // 
            this.tvModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModel.FullRowSelect = true;
            this.tvModel.HideSelection = false;
            this.tvModel.Location = new System.Drawing.Point(0, 0);
            this.tvModel.Name = "tvModel";
            this.tvModel.Size = new System.Drawing.Size(260, 586);
            this.tvModel.TabIndex = 0;
            this.tvModel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModel_AfterSelect);
            // 
            // pgNodeProperties
            // 
            this.pgNodeProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgNodeProperties.HelpVisible = false;
            this.pgNodeProperties.Location = new System.Drawing.Point(0, 124);
            this.pgNodeProperties.Name = "pgNodeProperties";
            this.pgNodeProperties.Size = new System.Drawing.Size(520, 462);
            this.pgNodeProperties.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gpGeneralInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panel1.Size = new System.Drawing.Size(520, 124);
            this.panel1.TabIndex = 1;
            // 
            // gpGeneralInfo
            // 
            this.gpGeneralInfo.Controls.Add(this.txtExternalId);
            this.gpGeneralInfo.Controls.Add(this.txtCategory);
            this.gpGeneralInfo.Controls.Add(this.txtName);
            this.gpGeneralInfo.Controls.Add(this.lblDbId);
            this.gpGeneralInfo.Controls.Add(this.label4);
            this.gpGeneralInfo.Controls.Add(this.label99);
            this.gpGeneralInfo.Controls.Add(this.label2);
            this.gpGeneralInfo.Controls.Add(this.label1);
            this.gpGeneralInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpGeneralInfo.Location = new System.Drawing.Point(0, 0);
            this.gpGeneralInfo.Name = "gpGeneralInfo";
            this.gpGeneralInfo.Size = new System.Drawing.Size(515, 124);
            this.gpGeneralInfo.TabIndex = 0;
            this.gpGeneralInfo.TabStop = false;
            this.gpGeneralInfo.Text = "General";
            // 
            // txtExternalId
            // 
            this.txtExternalId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalId.Location = new System.Drawing.Point(108, 92);
            this.txtExternalId.Name = "txtExternalId";
            this.txtExternalId.Size = new System.Drawing.Size(387, 21);
            this.txtExternalId.TabIndex = 7;
            this.txtExternalId.TextChanged += new System.EventHandler(this.txtExternalId_TextChanged);
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(108, 69);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(387, 21);
            this.txtCategory.TabIndex = 6;
            this.txtCategory.TextChanged += new System.EventHandler(this.txtCategory_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(108, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(387, 21);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDbId
            // 
            this.lblDbId.AutoSize = true;
            this.lblDbId.Location = new System.Drawing.Point(106, 26);
            this.lblDbId.Name = "lblDbId";
            this.lblDbId.Size = new System.Drawing.Size(41, 12);
            this.lblDbId.TabIndex = 4;
            this.lblDbId.Text = "[DbId]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Category";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(19, 95);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(65, 12);
            this.label99.TabIndex = 2;
            this.label99.Text = "ExternalId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "DbId";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.toolStripMenuItem3,
            this.exportPropertiesToJsonToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(178, 22);
            this.tsmiSave.Text = "&Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(175, 6);
            // 
            // exportPropertiesToJsonToolStripMenuItem
            // 
            this.exportPropertiesToJsonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportJson});
            this.exportPropertiesToJsonToolStripMenuItem.Name = "exportPropertiesToJsonToolStripMenuItem";
            this.exportPropertiesToJsonToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exportPropertiesToJsonToolStripMenuItem.Text = "Export Properties";
            // 
            // tsmiExportJson
            // 
            this.tsmiExportJson.Name = "tsmiExportJson";
            this.tsmiExportJson.Size = new System.Drawing.Size(108, 22);
            this.tsmiExportJson.Text = "JSON";
            this.tsmiExportJson.Click += new System.EventHandler(this.tsmiExportJson_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmiExit.Size = new System.Drawing.Size(178, 22);
            this.tsmiExit.Text = "E&xit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLicenseStatus,
            this.tsmiGithub,
            this.toolStripMenuItem2,
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // tsmiLicenseStatus
            // 
            this.tsmiLicenseStatus.Name = "tsmiLicenseStatus";
            this.tsmiLicenseStatus.Size = new System.Drawing.Size(247, 22);
            this.tsmiLicenseStatus.Text = "&License Status";
            this.tsmiLicenseStatus.Click += new System.EventHandler(this.tsmiLicenseStatus_Click);
            // 
            // tsmiGithub
            // 
            this.tsmiGithub.Name = "tsmiGithub";
            this.tsmiGithub.Size = new System.Drawing.Size(247, 22);
            this.tsmiGithub.Text = "&Github Source Code";
            this.tsmiGithub.Click += new System.EventHandler(this.tsmiGithub_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(244, 6);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(247, 22);
            this.tsmiAbout.Text = "&About ForgeAuthor Inspector";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // sfdExportToJson
            // 
            this.sfdExportToJson.DefaultExt = "json";
            this.sfdExportToJson.Filter = "JSON File|*.json|All File|*.*";
            this.sfdExportToJson.Title = "Export To JSON";
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormApp";
            this.Text = "ForgeAuthor Inspector";
            this.Load += new System.EventHandler(this.FormApp_Load);
            this.Shown += new System.EventHandler(this.FormApp_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gpGeneralInfo.ResumeLayout(false);
            this.gpGeneralInfo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvModel;
        private System.Windows.Forms.PropertyGrid pgNodeProperties;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gpGeneralInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.Label lblDbId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExternalId;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiLicenseStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exportPropertiesToJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportJson;
        private System.Windows.Forms.SaveFileDialog sfdExportToJson;
        private System.Windows.Forms.ToolStripMenuItem tsmiGithub;
    }
}

