namespace SourceCodeCounter.GUI
{
    partial class SourceInfoDlg
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
            this.BasePanel = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.BlankLinesPanel = new System.Windows.Forms.Panel();
            this.tbBlankLines = new System.Windows.Forms.TextBox();
            this.lblBlanks = new System.Windows.Forms.Label();
            this.CommentsPanel = new System.Windows.Forms.Panel();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.CodeLinesPanel = new System.Windows.Forms.Panel();
            this.tbCodeLines = new System.Windows.Forms.TextBox();
            this.lblCodeLines = new System.Windows.Forms.Label();
            this.TotalLinesPanel = new System.Windows.Forms.Panel();
            this.tbTotalLines = new System.Windows.Forms.TextBox();
            this.lblTotalLines = new System.Windows.Forms.Label();
            this.CurrentLinePanel = new System.Windows.Forms.Panel();
            this.tbCurrentLine = new System.Windows.Forms.TextBox();
            this.lblCurrentLine = new System.Windows.Forms.Label();
            this.ResultsPanel = new System.Windows.Forms.Panel();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.ProjectPanel = new System.Windows.Forms.Panel();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.bwTask = new System.ComponentModel.BackgroundWorker();
            this.BasePanel.SuspendLayout();
            this.BlankLinesPanel.SuspendLayout();
            this.CommentsPanel.SuspendLayout();
            this.CodeLinesPanel.SuspendLayout();
            this.TotalLinesPanel.SuspendLayout();
            this.CurrentLinePanel.SuspendLayout();
            this.ResultsPanel.SuspendLayout();
            this.ProjectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasePanel
            // 
            this.BasePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BasePanel.Controls.Add(this.progressBar);
            this.BasePanel.Controls.Add(this.BlankLinesPanel);
            this.BasePanel.Controls.Add(this.CommentsPanel);
            this.BasePanel.Controls.Add(this.CodeLinesPanel);
            this.BasePanel.Controls.Add(this.TotalLinesPanel);
            this.BasePanel.Controls.Add(this.CurrentLinePanel);
            this.BasePanel.Controls.Add(this.ResultsPanel);
            this.BasePanel.Controls.Add(this.ProjectPanel);
            this.BasePanel.Location = new System.Drawing.Point(13, 14);
            this.BasePanel.Name = "BasePanel";
            this.BasePanel.Size = new System.Drawing.Size(499, 173);
            this.BasePanel.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 140);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(474, 23);
            this.progressBar.TabIndex = 7;
            // 
            // BlankLinesPanel
            // 
            this.BlankLinesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlankLinesPanel.Controls.Add(this.tbBlankLines);
            this.BlankLinesPanel.Controls.Add(this.lblBlanks);
            this.BlankLinesPanel.Location = new System.Drawing.Point(332, 108);
            this.BlankLinesPanel.Name = "BlankLinesPanel";
            this.BlankLinesPanel.Size = new System.Drawing.Size(154, 26);
            this.BlankLinesPanel.TabIndex = 6;
            // 
            // tbBlankLines
            // 
            this.tbBlankLines.BackColor = System.Drawing.SystemColors.Control;
            this.tbBlankLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBlankLines.Location = new System.Drawing.Point(46, 5);
            this.tbBlankLines.Name = "tbBlankLines";
            this.tbBlankLines.Size = new System.Drawing.Size(101, 15);
            this.tbBlankLines.TabIndex = 3;
            this.tbBlankLines.Text = "0";
            this.tbBlankLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBlanks
            // 
            this.lblBlanks.AutoSize = true;
            this.lblBlanks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlanks.Location = new System.Drawing.Point(2, 6);
            this.lblBlanks.Name = "lblBlanks";
            this.lblBlanks.Size = new System.Drawing.Size(44, 13);
            this.lblBlanks.TabIndex = 0;
            this.lblBlanks.Text = "Blanks:";
            // 
            // CommentsPanel
            // 
            this.CommentsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommentsPanel.Controls.Add(this.tbComments);
            this.CommentsPanel.Controls.Add(this.lblComments);
            this.CommentsPanel.Location = new System.Drawing.Point(172, 108);
            this.CommentsPanel.Name = "CommentsPanel";
            this.CommentsPanel.Size = new System.Drawing.Size(154, 26);
            this.CommentsPanel.TabIndex = 5;
            // 
            // tbComments
            // 
            this.tbComments.BackColor = System.Drawing.SystemColors.Control;
            this.tbComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbComments.Location = new System.Drawing.Point(68, 5);
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(80, 15);
            this.tbComments.TabIndex = 3;
            this.tbComments.Text = "0";
            this.tbComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.Location = new System.Drawing.Point(2, 6);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(66, 13);
            this.lblComments.TabIndex = 0;
            this.lblComments.Text = "Comments:";
            // 
            // CodeLinesPanel
            // 
            this.CodeLinesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeLinesPanel.Controls.Add(this.tbCodeLines);
            this.CodeLinesPanel.Controls.Add(this.lblCodeLines);
            this.CodeLinesPanel.Location = new System.Drawing.Point(12, 108);
            this.CodeLinesPanel.Name = "CodeLinesPanel";
            this.CodeLinesPanel.Size = new System.Drawing.Size(154, 26);
            this.CodeLinesPanel.TabIndex = 4;
            // 
            // tbCodeLines
            // 
            this.tbCodeLines.BackColor = System.Drawing.SystemColors.Control;
            this.tbCodeLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCodeLines.Location = new System.Drawing.Point(39, 5);
            this.tbCodeLines.Name = "tbCodeLines";
            this.tbCodeLines.Size = new System.Drawing.Size(109, 15);
            this.tbCodeLines.TabIndex = 2;
            this.tbCodeLines.Text = "0";
            this.tbCodeLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCodeLines
            // 
            this.lblCodeLines.AutoSize = true;
            this.lblCodeLines.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeLines.Location = new System.Drawing.Point(2, 6);
            this.lblCodeLines.Name = "lblCodeLines";
            this.lblCodeLines.Size = new System.Drawing.Size(37, 13);
            this.lblCodeLines.TabIndex = 0;
            this.lblCodeLines.Text = "Code:";
            // 
            // TotalLinesPanel
            // 
            this.TotalLinesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalLinesPanel.Controls.Add(this.tbTotalLines);
            this.TotalLinesPanel.Controls.Add(this.lblTotalLines);
            this.TotalLinesPanel.Location = new System.Drawing.Point(252, 76);
            this.TotalLinesPanel.Name = "TotalLinesPanel";
            this.TotalLinesPanel.Size = new System.Drawing.Size(234, 26);
            this.TotalLinesPanel.TabIndex = 3;
            // 
            // tbTotalLines
            // 
            this.tbTotalLines.BackColor = System.Drawing.SystemColors.Control;
            this.tbTotalLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTotalLines.Location = new System.Drawing.Point(64, 5);
            this.tbTotalLines.Name = "tbTotalLines";
            this.tbTotalLines.Size = new System.Drawing.Size(163, 15);
            this.tbTotalLines.TabIndex = 2;
            this.tbTotalLines.Text = "0";
            this.tbTotalLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalLines
            // 
            this.lblTotalLines.AutoSize = true;
            this.lblTotalLines.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLines.Location = new System.Drawing.Point(2, 6);
            this.lblTotalLines.Name = "lblTotalLines";
            this.lblTotalLines.Size = new System.Drawing.Size(63, 13);
            this.lblTotalLines.TabIndex = 0;
            this.lblTotalLines.Text = "Total lines:";
            // 
            // CurrentLinePanel
            // 
            this.CurrentLinePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentLinePanel.Controls.Add(this.tbCurrentLine);
            this.CurrentLinePanel.Controls.Add(this.lblCurrentLine);
            this.CurrentLinePanel.Location = new System.Drawing.Point(12, 76);
            this.CurrentLinePanel.Name = "CurrentLinePanel";
            this.CurrentLinePanel.Size = new System.Drawing.Size(234, 26);
            this.CurrentLinePanel.TabIndex = 2;
            // 
            // tbCurrentLine
            // 
            this.tbCurrentLine.BackColor = System.Drawing.SystemColors.Control;
            this.tbCurrentLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCurrentLine.Location = new System.Drawing.Point(94, 5);
            this.tbCurrentLine.Name = "tbCurrentLine";
            this.tbCurrentLine.Size = new System.Drawing.Size(132, 15);
            this.tbCurrentLine.TabIndex = 1;
            this.tbCurrentLine.Text = "0";
            this.tbCurrentLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCurrentLine
            // 
            this.lblCurrentLine.AutoSize = true;
            this.lblCurrentLine.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLine.Location = new System.Drawing.Point(2, 6);
            this.lblCurrentLine.Name = "lblCurrentLine";
            this.lblCurrentLine.Size = new System.Drawing.Size(88, 13);
            this.lblCurrentLine.TabIndex = 0;
            this.lblCurrentLine.Text = "Unknown lines:";
            // 
            // ResultsPanel
            // 
            this.ResultsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultsPanel.Controls.Add(this.tbResults);
            this.ResultsPanel.Controls.Add(this.lblResult);
            this.ResultsPanel.Location = new System.Drawing.Point(12, 44);
            this.ResultsPanel.Name = "ResultsPanel";
            this.ResultsPanel.Size = new System.Drawing.Size(474, 26);
            this.ResultsPanel.TabIndex = 1;
            // 
            // tbResults
            // 
            this.tbResults.BackColor = System.Drawing.SystemColors.Control;
            this.tbResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbResults.Location = new System.Drawing.Point(62, 5);
            this.tbResults.Name = "tbResults";
            this.tbResults.Size = new System.Drawing.Size(405, 15);
            this.tbResults.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(2, 6);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(58, 13);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Scanning:";
            // 
            // ProjectPanel
            // 
            this.ProjectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProjectPanel.Controls.Add(this.tbProject);
            this.ProjectPanel.Controls.Add(this.lblProject);
            this.ProjectPanel.Location = new System.Drawing.Point(12, 12);
            this.ProjectPanel.Name = "ProjectPanel";
            this.ProjectPanel.Size = new System.Drawing.Size(474, 26);
            this.ProjectPanel.TabIndex = 0;
            // 
            // tbProject
            // 
            this.tbProject.BackColor = System.Drawing.SystemColors.Control;
            this.tbProject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProject.Location = new System.Drawing.Point(50, 5);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(418, 15);
            this.tbProject.TabIndex = 1;
            this.tbProject.Text = "C:\\Program Files\\Borland\\Delphi7\\";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(2, 6);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(46, 13);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project:";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(160, 193);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 30);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "&Scan";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(266, 193);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 30);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // bwTask
            // 
            this.bwTask.WorkerReportsProgress = true;
            this.bwTask.WorkerSupportsCancellation = true;
            this.bwTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnBackgroundWorkerTaskDoWork);
            this.bwTask.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnBackgroundWorkerTaskProgressChanged);
            this.bwTask.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnBackgroundWorkerTaskCompleted);
            // 
            // SourceInfoDlg
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 235);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.BasePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SourceInfoDlg";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scaning";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SourceInfoDlg_FormClosing);
            this.Load += new System.EventHandler(this.SourceInfoDlg_Load);
            this.BasePanel.ResumeLayout(false);
            this.BlankLinesPanel.ResumeLayout(false);
            this.BlankLinesPanel.PerformLayout();
            this.CommentsPanel.ResumeLayout(false);
            this.CommentsPanel.PerformLayout();
            this.CodeLinesPanel.ResumeLayout(false);
            this.CodeLinesPanel.PerformLayout();
            this.TotalLinesPanel.ResumeLayout(false);
            this.TotalLinesPanel.PerformLayout();
            this.CurrentLinePanel.ResumeLayout(false);
            this.CurrentLinePanel.PerformLayout();
            this.ResultsPanel.ResumeLayout(false);
            this.ResultsPanel.PerformLayout();
            this.ProjectPanel.ResumeLayout(false);
            this.ProjectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BasePanel;
        private System.Windows.Forms.Panel BlankLinesPanel;
        private System.Windows.Forms.Panel CommentsPanel;
        private System.Windows.Forms.Panel CodeLinesPanel;
        private System.Windows.Forms.Panel TotalLinesPanel;
        private System.Windows.Forms.Panel CurrentLinePanel;
        private System.Windows.Forms.Panel ResultsPanel;
        private System.Windows.Forms.Panel ProjectPanel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label lblBlanks;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblCodeLines;
        private System.Windows.Forms.Label lblTotalLines;
        private System.Windows.Forms.Label lblCurrentLine;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TextBox tbBlankLines;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.TextBox tbCodeLines;
        private System.Windows.Forms.TextBox tbTotalLines;
        private System.Windows.Forms.TextBox tbCurrentLine;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.Button CancelButton;
        private System.ComponentModel.BackgroundWorker bwTask;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}