namespace Bimangle.ForgeAuthor.Merger
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvSourceModels = new System.Windows.Forms.DataGridView();
            this.modelTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.svfModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.dlgSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubSourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutForgeAuthorMergerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSourceModels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svfModelBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dgvSourceModels);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Select Source Svf Models";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(17, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvSourceModels
            // 
            this.dgvSourceModels.AllowUserToAddRows = false;
            this.dgvSourceModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSourceModels.AutoGenerateColumns = false;
            this.dgvSourceModels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSourceModels.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSourceModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSourceModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modelTitleDataGridViewTextBoxColumn,
            this.modelPathDataGridViewTextBoxColumn});
            this.dgvSourceModels.DataSource = this.svfModelBindingSource;
            this.dgvSourceModels.Location = new System.Drawing.Point(17, 30);
            this.dgvSourceModels.Name = "dgvSourceModels";
            this.dgvSourceModels.RowTemplate.Height = 23;
            this.dgvSourceModels.Size = new System.Drawing.Size(558, 124);
            this.dgvSourceModels.TabIndex = 0;
            // 
            // modelTitleDataGridViewTextBoxColumn
            // 
            this.modelTitleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.modelTitleDataGridViewTextBoxColumn.DataPropertyName = "ModelTitle";
            this.modelTitleDataGridViewTextBoxColumn.HeaderText = "Model Title";
            this.modelTitleDataGridViewTextBoxColumn.MinimumWidth = 120;
            this.modelTitleDataGridViewTextBoxColumn.Name = "modelTitleDataGridViewTextBoxColumn";
            this.modelTitleDataGridViewTextBoxColumn.Width = 120;
            // 
            // modelPathDataGridViewTextBoxColumn
            // 
            this.modelPathDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.modelPathDataGridViewTextBoxColumn.DataPropertyName = "ModelPath";
            this.modelPathDataGridViewTextBoxColumn.HeaderText = "Svf Model File Path";
            this.modelPathDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.modelPathDataGridViewTextBoxColumn.Name = "modelPathDataGridViewTextBoxColumn";
            this.modelPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.modelPathDataGridViewTextBoxColumn.Width = 150;
            // 
            // svfModelBindingSource
            // 
            this.svfModelBindingSource.DataSource = typeof(Bimangle.ForgeAuthor.Merger.Types.SvfModel);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnBrowseOutput);
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Select Output Path";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.Location = new System.Drawing.Point(530, 38);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(45, 23);
            this.btnBrowseOutput.TabIndex = 1;
            this.btnBrowseOutput.Text = "...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(17, 40);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(506, 21);
            this.txtOutput.TabIndex = 0;
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge.Location = new System.Drawing.Point(225, 342);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(152, 38);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
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
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(629, 25);
            this.menuMain.TabIndex = 3;
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
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 395);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "FormApp";
            this.Text = "ForgeAuthor Merger";
            this.Load += new System.EventHandler(this.FormApp_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSourceModels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svfModelBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSourceModels;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.FolderBrowserDialog dlgSelectFolder;
        private System.Windows.Forms.OpenFileDialog dlgSelectFile;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubSourceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutForgeAuthorMergerToolStripMenuItem;
        private System.Windows.Forms.BindingSource svfModelBindingSource;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelPathDataGridViewTextBoxColumn;
    }
}

