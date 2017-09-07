namespace Bimangle.ForgeAuthor.Differ
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubSourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutForgeAuthorMergerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrowseDiffModel = new System.Windows.Forms.Button();
            this.txtDiffModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseIncrementModel = new System.Windows.Forms.Button();
            this.txtIncrementModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseBaseModel = new System.Windows.Forms.Button();
            this.txtBaseModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dlgSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.menuMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(579, 25);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenseStatusToolStripMenuItem,
            this.githubSourceCodeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutForgeAuthorMergerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // licenseStatusToolStripMenuItem
            // 
            this.licenseStatusToolStripMenuItem.Name = "licenseStatusToolStripMenuItem";
            this.licenseStatusToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.licenseStatusToolStripMenuItem.Text = "&License Status";
            this.licenseStatusToolStripMenuItem.Click += new System.EventHandler(this.licenseStatusToolStripMenuItem_Click);
            // 
            // githubSourceCodeToolStripMenuItem
            // 
            this.githubSourceCodeToolStripMenuItem.Name = "githubSourceCodeToolStripMenuItem";
            this.githubSourceCodeToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.githubSourceCodeToolStripMenuItem.Text = "&Github Source Code";
            this.githubSourceCodeToolStripMenuItem.Click += new System.EventHandler(this.githubSourceCodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(233, 6);
            // 
            // aboutForgeAuthorMergerToolStripMenuItem
            // 
            this.aboutForgeAuthorMergerToolStripMenuItem.Name = "aboutForgeAuthorMergerToolStripMenuItem";
            this.aboutForgeAuthorMergerToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.aboutForgeAuthorMergerToolStripMenuItem.Text = "About ForgeAuthor Merger";
            this.aboutForgeAuthorMergerToolStripMenuItem.Click += new System.EventHandler(this.aboutForgeAuthorMergerToolStripMenuItem_Click);
            // 
            // btnBrowseDiffModel
            // 
            this.btnBrowseDiffModel.Location = new System.Drawing.Point(468, 37);
            this.btnBrowseDiffModel.Name = "btnBrowseDiffModel";
            this.btnBrowseDiffModel.Size = new System.Drawing.Size(44, 22);
            this.btnBrowseDiffModel.TabIndex = 2;
            this.btnBrowseDiffModel.Text = "...";
            this.btnBrowseDiffModel.UseVisualStyleBackColor = true;
            this.btnBrowseDiffModel.Click += new System.EventHandler(this.btnBrowseDiffModel_Click);
            // 
            // txtDiffModel
            // 
            this.txtDiffModel.Location = new System.Drawing.Point(19, 38);
            this.txtDiffModel.Name = "txtDiffModel";
            this.txtDiffModel.ReadOnly = true;
            this.txtDiffModel.Size = new System.Drawing.Size(443, 21);
            this.txtDiffModel.TabIndex = 1;
            this.txtDiffModel.TextChanged += new System.EventHandler(this.txtDiffModel_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Diff Model:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseIncrementModel);
            this.groupBox1.Controls.Add(this.txtIncrementModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBrowseBaseModel);
            this.groupBox1.Controls.Add(this.txtBaseModel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(22, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // btnBrowseIncrementModel
            // 
            this.btnBrowseIncrementModel.Location = new System.Drawing.Point(468, 90);
            this.btnBrowseIncrementModel.Name = "btnBrowseIncrementModel";
            this.btnBrowseIncrementModel.Size = new System.Drawing.Size(44, 22);
            this.btnBrowseIncrementModel.TabIndex = 5;
            this.btnBrowseIncrementModel.Text = "...";
            this.btnBrowseIncrementModel.UseVisualStyleBackColor = true;
            this.btnBrowseIncrementModel.Click += new System.EventHandler(this.btnBrowseIncrementModel_Click);
            // 
            // txtIncrementModel
            // 
            this.txtIncrementModel.Location = new System.Drawing.Point(19, 91);
            this.txtIncrementModel.Name = "txtIncrementModel";
            this.txtIncrementModel.ReadOnly = true;
            this.txtIncrementModel.Size = new System.Drawing.Size(443, 21);
            this.txtIncrementModel.TabIndex = 4;
            this.txtIncrementModel.TextChanged += new System.EventHandler(this.txtIncrementModel_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Increment Model:";
            // 
            // btnBrowseBaseModel
            // 
            this.btnBrowseBaseModel.Location = new System.Drawing.Point(468, 40);
            this.btnBrowseBaseModel.Name = "btnBrowseBaseModel";
            this.btnBrowseBaseModel.Size = new System.Drawing.Size(44, 22);
            this.btnBrowseBaseModel.TabIndex = 2;
            this.btnBrowseBaseModel.Text = "...";
            this.btnBrowseBaseModel.UseVisualStyleBackColor = true;
            this.btnBrowseBaseModel.Click += new System.EventHandler(this.btnBrowseBaseModel_Click);
            // 
            // txtBaseModel
            // 
            this.txtBaseModel.Location = new System.Drawing.Point(19, 41);
            this.txtBaseModel.Name = "txtBaseModel";
            this.txtBaseModel.ReadOnly = true;
            this.txtBaseModel.Size = new System.Drawing.Size(443, 21);
            this.txtBaseModel.TabIndex = 1;
            this.txtBaseModel.TextChanged += new System.EventHandler(this.txtBaseModel_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Base Model:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDiffModel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnBrowseDiffModel);
            this.groupBox2.Location = new System.Drawing.Point(22, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(452, 279);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(82, 32);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dlgSelectFolder
            // 
            this.dlgSelectFolder.Description = "Select Output Folder Path";
            this.dlgSelectFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // dlgSelectFile
            // 
            this.dlgSelectFile.Filter = "Autodesk Forge Svf Model|*.svf;*.svfzip|All Files|*.*";
            this.dlgSelectFile.Multiselect = true;
            this.dlgSelectFile.Title = "Select Source Autodesk Froge Svf Model";
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 330);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuMain);
            this.Name = "FormApp";
            this.Text = "ForgeAuthor Differ";
            this.Load += new System.EventHandler(this.FormApp_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubSourceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutForgeAuthorMergerToolStripMenuItem;
        private System.Windows.Forms.Button btnBrowseDiffModel;
        private System.Windows.Forms.TextBox txtDiffModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowseIncrementModel;
        private System.Windows.Forms.TextBox txtIncrementModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseBaseModel;
        private System.Windows.Forms.TextBox txtBaseModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.FolderBrowserDialog dlgSelectFolder;
        private System.Windows.Forms.OpenFileDialog dlgSelectFile;
    }
}

