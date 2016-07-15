namespace SourceCodeCounter.GUI
{
    partial class ProjectSelectionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectSelectionDialog));
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblProjectLocation = new System.Windows.Forms.Label();
            this.chkIncludeSubDir = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbProjectTitle = new System.Windows.Forms.TextBox();
            this.tbProjectPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbProjectType = new System.Windows.Forms.ComboBox();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(12, 22);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(33, 15);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "&Title:";
            // 
            // lblProjectLocation
            // 
            this.lblProjectLocation.AccessibleName = "L";
            this.lblProjectLocation.AutoSize = true;
            this.lblProjectLocation.Location = new System.Drawing.Point(12, 52);
            this.lblProjectLocation.Name = "lblProjectLocation";
            this.lblProjectLocation.Size = new System.Drawing.Size(56, 15);
            this.lblProjectLocation.TabIndex = 1;
            this.lblProjectLocation.Text = "&Location:";
            // 
            // chkIncludeSubDir
            // 
            this.chkIncludeSubDir.AutoSize = true;
            this.chkIncludeSubDir.Location = new System.Drawing.Point(15, 87);
            this.chkIncludeSubDir.Name = "chkIncludeSubDir";
            this.chkIncludeSubDir.Size = new System.Drawing.Size(147, 19);
            this.chkIncludeSubDir.TabIndex = 2;
            this.chkIncludeSubDir.Text = "Include sub-directories";
            this.chkIncludeSubDir.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(165, 116);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 31);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbProjectTitle
            // 
            this.tbProjectTitle.AccessibleDescription = "Project Title";
            this.tbProjectTitle.AccessibleName = "T";
            this.errorProvider.SetIconAlignment(this.tbProjectTitle, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.tbProjectTitle.Location = new System.Drawing.Point(68, 19);
            this.tbProjectTitle.Name = "tbProjectTitle";
            this.tbProjectTitle.Size = new System.Drawing.Size(257, 23);
            this.tbProjectTitle.TabIndex = 0;
            // 
            // tbProjectPath
            // 
            this.errorProvider.SetIconAlignment(this.tbProjectPath, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.tbProjectPath.Location = new System.Drawing.Point(68, 49);
            this.tbProjectPath.Name = "tbProjectPath";
            this.tbProjectPath.Size = new System.Drawing.Size(409, 23);
            this.tbProjectPath.TabIndex = 1;
            this.tbProjectPath.Leave += new System.EventHandler(this.tbProjectPath_Leave);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(480, 49);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cbProjectType
            // 
            this.cbProjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjectType.FormattingEnabled = true;
            this.cbProjectType.Items.AddRange(new object[] {
            "<User defined>",
            "Project File",
            "Solution File",
            "Source File",
            "SQL File",
            "Wildcard File"});
            this.cbProjectType.Location = new System.Drawing.Point(331, 19);
            this.cbProjectType.Name = "cbProjectType";
            this.cbProjectType.Size = new System.Drawing.Size(146, 23);
            this.cbProjectType.Sorted = true;
            this.cbProjectType.TabIndex = 5;
            // 
            // openFileDlg
            // 
            this.openFileDlg.DefaultExt = "dpr";
            this.openFileDlg.Filter = resources.GetString("openFileDlg.Filter");
            this.openFileDlg.InitialDirectory = "C:\\";
            this.openFileDlg.SupportMultiDottedExtensions = true;
            this.openFileDlg.Title = "Select Project Folder";
            // 
            // ProjectSelectionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 159);
            this.Controls.Add(this.cbProjectType);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbProjectPath);
            this.Controls.Add(this.tbProjectTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkIncludeSubDir);
            this.Controls.Add(this.lblProjectLocation);
            this.Controls.Add(this.lblProjectName);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectSelectionDialog";
            this.Text = "Project Selection";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblProjectLocation;
        private System.Windows.Forms.CheckBox chkIncludeSubDir;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbProjectTitle;
        private System.Windows.Forms.TextBox tbProjectPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cbProjectType;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
    }
}