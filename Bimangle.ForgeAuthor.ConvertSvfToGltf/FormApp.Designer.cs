namespace Bimangle.ForgeAuthor.ConvertSvfToGltf
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
            this.btnBrowseOutputFilePath = new System.Windows.Forms.Button();
            this.txtOutputFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseInputFilePath = new System.Windows.Forms.Button();
            this.txtInputFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cbExtractShell = new System.Windows.Forms.CheckBox();
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
            this.licenseStatusToolStripMenuItem.Size = new System.Drawing.Size(326, 22);
            this.licenseStatusToolStripMenuItem.Text = "&License Status";
            this.licenseStatusToolStripMenuItem.Click += new System.EventHandler(this.licenseStatusToolStripMenuItem_Click);
            // 
            // githubSourceCodeToolStripMenuItem
            // 
            this.githubSourceCodeToolStripMenuItem.Name = "githubSourceCodeToolStripMenuItem";
            this.githubSourceCodeToolStripMenuItem.Size = new System.Drawing.Size(326, 22);
            this.githubSourceCodeToolStripMenuItem.Text = "&Github Source Code";
            this.githubSourceCodeToolStripMenuItem.Click += new System.EventHandler(this.githubSourceCodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(323, 6);
            // 
            // aboutForgeAuthorMergerToolStripMenuItem
            // 
            this.aboutForgeAuthorMergerToolStripMenuItem.Name = "aboutForgeAuthorMergerToolStripMenuItem";
            this.aboutForgeAuthorMergerToolStripMenuItem.Size = new System.Drawing.Size(326, 22);
            this.aboutForgeAuthorMergerToolStripMenuItem.Text = "About ForgeAuthor Convert Svf to glTF/glb";
            this.aboutForgeAuthorMergerToolStripMenuItem.Click += new System.EventHandler(this.aboutForgeAuthorMergerToolStripMenuItem_Click);
            // 
            // btnBrowseOutputFilePath
            // 
            this.btnBrowseOutputFilePath.Location = new System.Drawing.Point(468, 37);
            this.btnBrowseOutputFilePath.Name = "btnBrowseOutputFilePath";
            this.btnBrowseOutputFilePath.Size = new System.Drawing.Size(44, 22);
            this.btnBrowseOutputFilePath.TabIndex = 2;
            this.btnBrowseOutputFilePath.Text = "...";
            this.btnBrowseOutputFilePath.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFilePath.Click += new System.EventHandler(this.btnBrowseDiffModel_Click);
            // 
            // txtOutputFilePath
            // 
            this.txtOutputFilePath.Location = new System.Drawing.Point(19, 38);
            this.txtOutputFilePath.Name = "txtOutputFilePath";
            this.txtOutputFilePath.ReadOnly = true;
            this.txtOutputFilePath.Size = new System.Drawing.Size(443, 21);
            this.txtOutputFilePath.TabIndex = 1;
            this.txtOutputFilePath.TextChanged += new System.EventHandler(this.txtDiffModel_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "*.gltf/*.glb Model:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseInputFilePath);
            this.groupBox1.Controls.Add(this.txtInputFilePath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(22, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // btnBrowseInputFilePath
            // 
            this.btnBrowseInputFilePath.Location = new System.Drawing.Point(468, 40);
            this.btnBrowseInputFilePath.Name = "btnBrowseInputFilePath";
            this.btnBrowseInputFilePath.Size = new System.Drawing.Size(44, 22);
            this.btnBrowseInputFilePath.TabIndex = 2;
            this.btnBrowseInputFilePath.Text = "...";
            this.btnBrowseInputFilePath.UseVisualStyleBackColor = true;
            this.btnBrowseInputFilePath.Click += new System.EventHandler(this.btnBrowseBaseModel_Click);
            // 
            // txtInputFilePath
            // 
            this.txtInputFilePath.Location = new System.Drawing.Point(19, 41);
            this.txtInputFilePath.Name = "txtInputFilePath";
            this.txtInputFilePath.ReadOnly = true;
            this.txtInputFilePath.Size = new System.Drawing.Size(443, 21);
            this.txtInputFilePath.TabIndex = 1;
            this.txtInputFilePath.TextChanged += new System.EventHandler(this.txtBaseModel_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "*.svf/*.svfzip Model:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbExtractShell);
            this.groupBox2.Controls.Add(this.txtOutputFilePath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnBrowseOutputFilePath);
            this.groupBox2.Location = new System.Drawing.Point(22, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 103);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(226, 233);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 32);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Start Convert";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dlgSelectFile
            // 
            this.dlgSelectFile.Filter = "Svf Model|*.svf;*.svfzip|All Files|*.*";
            this.dlgSelectFile.Multiselect = true;
            this.dlgSelectFile.Title = "Select Source Autodesk Froge Svf Model";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "glTF™ (GL Transmission Format)|*.gltf|glTF™ Binary (GL Transmission Binary Format" +
    ")|*.glb|All Files|*.*";
            // 
            // cbExtractShell
            // 
            this.cbExtractShell.AutoSize = true;
            this.cbExtractShell.Location = new System.Drawing.Point(19, 66);
            this.cbExtractShell.Name = "cbExtractShell";
            this.cbExtractShell.Size = new System.Drawing.Size(168, 16);
            this.cbExtractShell.TabIndex = 3;
            this.cbExtractShell.Text = "Extract Building\'s Shell";
            this.cbExtractShell.UseVisualStyleBackColor = true;
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 277);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuMain);
            this.Name = "FormApp";
            this.Text = "ForgeAuthor Convert Svf to glTF/glb";
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
        private System.Windows.Forms.Button btnBrowseOutputFilePath;
        private System.Windows.Forms.TextBox txtOutputFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowseInputFilePath;
        private System.Windows.Forms.TextBox txtInputFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.OpenFileDialog dlgSelectFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox cbExtractShell;
    }
}

