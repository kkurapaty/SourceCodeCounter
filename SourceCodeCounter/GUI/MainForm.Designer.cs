namespace SourceCodeCounter.GUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ButtonGCCollect = new System.Windows.Forms.Button();
            this.checkFreezeHeader = new System.Windows.Forms.CheckBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkClearResults = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvProjects = new System.Windows.Forms.ListView();
            this.chProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProjectPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRecursive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniClearItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mniScanSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniTPlusProjects = new System.Windows.Forms.ToolStripMenuItem();
            this.myProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblProjects = new System.Windows.Forms.Label();
            this.chkPercentage = new System.Windows.Forms.CheckBox();
            this.chkSummary = new System.Windows.Forms.CheckBox();
            this.chkProjects = new System.Windows.Forms.CheckBox();
            this.chkFiles = new System.Windows.Forms.CheckBox();
            this.lblShow = new System.Windows.Forms.Label();
            this.panelTabContent = new System.Windows.Forms.Panel();
            this.tbHeader = new System.Windows.Forms.TextBox();
            this.rtDebug = new System.Windows.Forms.RichTextBox();
            this.rtResults = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusPanel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPanel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelTabContent.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.ButtonGCCollect);
            this.splitContainer1.Panel1.Controls.Add(this.checkFreezeHeader);
            this.splitContainer1.Panel1.Controls.Add(this.btnAbout);
            this.splitContainer1.Panel1.Controls.Add(this.btnStop);
            this.splitContainer1.Panel1.Controls.Add(this.chkClearResults);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btnScan);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.lvProjects);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjects);
            this.splitContainer1.Panel1.Controls.Add(this.chkPercentage);
            this.splitContainer1.Panel1.Controls.Add(this.chkSummary);
            this.splitContainer1.Panel1.Controls.Add(this.chkProjects);
            this.splitContainer1.Panel1.Controls.Add(this.chkFiles);
            this.splitContainer1.Panel1.Controls.Add(this.lblShow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelTabContent);
            this.splitContainer1.Size = new System.Drawing.Size(905, 653);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(430, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 62);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(185, 36);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(65, 19);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "gcClass";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(108, 37);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(44, 19);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "this";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(8, 37);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 19);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "TabControl";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(185, 12);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(73, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "TaskArgs";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(108, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "ASync";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "StopWatch";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // ButtonGCCollect
            // 
            this.ButtonGCCollect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGCCollect.ForeColor = System.Drawing.Color.Navy;
            this.ButtonGCCollect.Location = new System.Drawing.Point(617, 146);
            this.ButtonGCCollect.Name = "ButtonGCCollect";
            this.ButtonGCCollect.Size = new System.Drawing.Size(87, 27);
            this.ButtonGCCollect.TabIndex = 12;
            this.ButtonGCCollect.Text = "GC Collect";
            this.ButtonGCCollect.UseVisualStyleBackColor = true;
            this.ButtonGCCollect.Visible = false;
            this.ButtonGCCollect.Click += new System.EventHandler(this.ButtonGCCollect_Click);
            // 
            // checkFreezeHeader
            // 
            this.checkFreezeHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkFreezeHeader.AutoSize = true;
            this.checkFreezeHeader.Location = new System.Drawing.Point(709, 62);
            this.checkFreezeHeader.Name = "checkFreezeHeader";
            this.checkFreezeHeader.Size = new System.Drawing.Size(100, 19);
            this.checkFreezeHeader.TabIndex = 5;
            this.checkFreezeHeader.Text = "Freeze Header";
            this.checkFreezeHeader.UseVisualStyleBackColor = true;
            this.checkFreezeHeader.CheckedChanged += new System.EventHandler(this.checkFreezeHeader_CheckedChanged);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnAbout.Location = new System.Drawing.Point(710, 147);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(87, 27);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "&About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(709, 111);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 27);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkClearResults
            // 
            this.chkClearResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClearResults.AutoSize = true;
            this.chkClearResults.Checked = true;
            this.chkClearResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearResults.Location = new System.Drawing.Point(709, 87);
            this.chkClearResults.Name = "chkClearResults";
            this.chkClearResults.Size = new System.Drawing.Size(158, 19);
            this.chkClearResults.TabIndex = 6;
            this.chkClearResults.Text = "Clear Results before Scan";
            this.chkClearResults.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(801, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.Enabled = false;
            this.btnScan.Location = new System.Drawing.Point(710, 111);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(87, 27);
            this.btnScan.TabIndex = 8;
            this.btnScan.Text = "&Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(800, 112);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 27);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lvProjects
            // 
            this.lvProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProject,
            this.chProjectPath,
            this.chRecursive});
            this.lvProjects.ContextMenuStrip = this.contextMenuStrip1;
            this.lvProjects.FullRowSelect = true;
            this.lvProjects.HideSelection = false;
            this.lvProjects.Location = new System.Drawing.Point(17, 27);
            this.lvProjects.Name = "lvProjects";
            this.lvProjects.ShowItemToolTips = true;
            this.lvProjects.Size = new System.Drawing.Size(631, 146);
            this.lvProjects.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProjects.TabIndex = 0;
            this.lvProjects.UseCompatibleStateImageBehavior = false;
            this.lvProjects.View = System.Windows.Forms.View.Details;
            this.lvProjects.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvProjects_ItemSelectionChanged);
            // 
            // chProject
            // 
            this.chProject.Text = "Project Name";
            this.chProject.Width = 100;
            // 
            // chProjectPath
            // 
            this.chProjectPath.Text = "Path (with Mask)";
            this.chProjectPath.Width = 461;
            // 
            // chRecursive
            // 
            this.chRecursive.Text = "Sub Dir";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddItem,
            this.mniEditItem,
            this.mniRemoveItem,
            this.toolStripMenuItem1,
            this.mniClearItems,
            this.mniScanSelected,
            this.toolStripMenuItem2,
            this.mniTPlusProjects,
            this.myProjectsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(200, 170);
            // 
            // mniAddItem
            // 
            this.mniAddItem.Name = "mniAddItem";
            this.mniAddItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mniAddItem.Size = new System.Drawing.Size(199, 22);
            this.mniAddItem.Text = "Add";
            this.mniAddItem.Click += new System.EventHandler(this.mniAddItem_Click);
            // 
            // mniEditItem
            // 
            this.mniEditItem.Name = "mniEditItem";
            this.mniEditItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mniEditItem.Size = new System.Drawing.Size(199, 22);
            this.mniEditItem.Text = "Edit";
            this.mniEditItem.Click += new System.EventHandler(this.mniEditItem_Click);
            // 
            // mniRemoveItem
            // 
            this.mniRemoveItem.Name = "mniRemoveItem";
            this.mniRemoveItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mniRemoveItem.Size = new System.Drawing.Size(199, 22);
            this.mniRemoveItem.Text = "Remove";
            this.mniRemoveItem.Click += new System.EventHandler(this.mniRemoveItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 6);
            // 
            // mniClearItems
            // 
            this.mniClearItems.Name = "mniClearItems";
            this.mniClearItems.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.mniClearItems.Size = new System.Drawing.Size(199, 22);
            this.mniClearItems.Text = "Clear";
            this.mniClearItems.Click += new System.EventHandler(this.mniClearItems_Click);
            // 
            // mniScanSelected
            // 
            this.mniScanSelected.Name = "mniScanSelected";
            this.mniScanSelected.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F9)));
            this.mniScanSelected.Size = new System.Drawing.Size(199, 22);
            this.mniScanSelected.Text = "Scan Selected";
            this.mniScanSelected.Click += new System.EventHandler(this.mniScanSelectedProject_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(196, 6);
            // 
            // mniTPlusProjects
            // 
            this.mniTPlusProjects.Name = "mniTPlusProjects";
            this.mniTPlusProjects.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mniTPlusProjects.Size = new System.Drawing.Size(199, 22);
            this.mniTPlusProjects.Text = "Default Projects";
            this.mniTPlusProjects.Click += new System.EventHandler(this.mniTPlusProjects_Click);
            // 
            // myProjectsToolStripMenuItem
            // 
            this.myProjectsToolStripMenuItem.Name = "myProjectsToolStripMenuItem";
            this.myProjectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.myProjectsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.myProjectsToolStripMenuItem.Text = "My Projects";
            this.myProjectsToolStripMenuItem.Click += new System.EventHandler(this.myProjectsToolStripMenuItem_Click);
            // 
            // lblProjects
            // 
            this.lblProjects.AutoSize = true;
            this.lblProjects.Location = new System.Drawing.Point(14, 9);
            this.lblProjects.Name = "lblProjects";
            this.lblProjects.Size = new System.Drawing.Size(159, 15);
            this.lblProjects.TabIndex = 5;
            this.lblProjects.Text = "Please enter Projects to scan:";
            // 
            // chkPercentage
            // 
            this.chkPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPercentage.AutoSize = true;
            this.chkPercentage.Location = new System.Drawing.Point(800, 37);
            this.chkPercentage.Name = "chkPercentage";
            this.chkPercentage.Size = new System.Drawing.Size(85, 19);
            this.chkPercentage.TabIndex = 4;
            this.chkPercentage.Text = "Percentage";
            this.chkPercentage.UseVisualStyleBackColor = true;
            // 
            // chkSummary
            // 
            this.chkSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSummary.AutoSize = true;
            this.chkSummary.Checked = true;
            this.chkSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSummary.Location = new System.Drawing.Point(709, 37);
            this.chkSummary.Name = "chkSummary";
            this.chkSummary.Size = new System.Drawing.Size(77, 19);
            this.chkSummary.TabIndex = 3;
            this.chkSummary.Text = "Summary";
            this.chkSummary.UseVisualStyleBackColor = true;
            // 
            // chkProjects
            // 
            this.chkProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkProjects.AutoSize = true;
            this.chkProjects.Checked = true;
            this.chkProjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProjects.Location = new System.Drawing.Point(800, 12);
            this.chkProjects.Name = "chkProjects";
            this.chkProjects.Size = new System.Drawing.Size(68, 19);
            this.chkProjects.TabIndex = 2;
            this.chkProjects.Text = "Projects";
            this.chkProjects.UseVisualStyleBackColor = true;
            // 
            // chkFiles
            // 
            this.chkFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFiles.AutoSize = true;
            this.chkFiles.Location = new System.Drawing.Point(710, 12);
            this.chkFiles.Name = "chkFiles";
            this.chkFiles.Size = new System.Drawing.Size(49, 19);
            this.chkFiles.TabIndex = 1;
            this.chkFiles.Text = "Files";
            this.chkFiles.UseVisualStyleBackColor = true;
            // 
            // lblShow
            // 
            this.lblShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(665, 13);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(39, 15);
            this.lblShow.TabIndex = 0;
            this.lblShow.Text = "Show:";
            // 
            // panelTabContent
            // 
            this.panelTabContent.BackColor = System.Drawing.Color.White;
            this.panelTabContent.Controls.Add(this.tbHeader);
            this.panelTabContent.Controls.Add(this.rtDebug);
            this.panelTabContent.Controls.Add(this.rtResults);
            this.panelTabContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabContent.Location = new System.Drawing.Point(0, 0);
            this.panelTabContent.Name = "panelTabContent";
            this.panelTabContent.Size = new System.Drawing.Size(905, 461);
            this.panelTabContent.TabIndex = 1;
            // 
            // tbHeader
            // 
            this.tbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbHeader.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeader.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbHeader.Location = new System.Drawing.Point(17, 332);
            this.tbHeader.Multiline = true;
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.ReadOnly = true;
            this.tbHeader.Size = new System.Drawing.Size(835, 42);
            this.tbHeader.TabIndex = 4;
            this.tbHeader.Text = resources.GetString("tbHeader.Text");
            // 
            // rtDebug
            // 
            this.rtDebug.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtDebug.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtDebug.Location = new System.Drawing.Point(17, 173);
            this.rtDebug.Name = "rtDebug";
            this.rtDebug.ReadOnly = true;
            this.rtDebug.Size = new System.Drawing.Size(481, 140);
            this.rtDebug.TabIndex = 3;
            this.rtDebug.Text = "";
            // 
            // rtResults
            // 
            this.rtResults.BackColor = System.Drawing.SystemColors.Window;
            this.rtResults.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtResults.Location = new System.Drawing.Point(17, 11);
            this.rtResults.Name = "rtResults";
            this.rtResults.ReadOnly = true;
            this.rtResults.Size = new System.Drawing.Size(481, 147);
            this.rtResults.TabIndex = 2;
            this.rtResults.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusPanel1,
            this.statusPanel2,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 653);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(905, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusPanel1
            // 
            this.statusPanel1.Name = "statusPanel1";
            this.statusPanel1.Size = new System.Drawing.Size(394, 17);
            this.statusPanel1.Spring = true;
            this.statusPanel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusPanel2
            // 
            this.statusPanel2.Name = "statusPanel2";
            this.statusPanel2.Size = new System.Drawing.Size(394, 17);
            this.statusPanel2.Spring = true;
            this.statusPanel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 675);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Source Code Scanner";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelTabContent.ResumeLayout(false);
            this.panelTabContent.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvProjects;
        private System.Windows.Forms.ColumnHeader chRecursive;
        private System.Windows.Forms.ColumnHeader chProject;
        private System.Windows.Forms.ColumnHeader chProjectPath;
        private System.Windows.Forms.Label lblProjects;
        private System.Windows.Forms.CheckBox chkPercentage;
        private System.Windows.Forms.CheckBox chkSummary;
        private System.Windows.Forms.CheckBox chkProjects;
        private System.Windows.Forms.CheckBox chkFiles;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mniAddItem;
        private System.Windows.Forms.ToolStripMenuItem mniEditItem;
        private System.Windows.Forms.ToolStripMenuItem mniRemoveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mniClearItems;
        private System.Windows.Forms.ToolStripMenuItem mniTPlusProjects;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel statusPanel1;
        private System.Windows.Forms.ToolStripStatusLabel statusPanel2;
        private System.Windows.Forms.CheckBox chkClearResults;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mniScanSelected;
        private System.Windows.Forms.Panel panelTabContent;
        private System.Windows.Forms.RichTextBox rtDebug;
        private System.Windows.Forms.RichTextBox rtResults;
        private System.Windows.Forms.CheckBox checkFreezeHeader;
        private System.Windows.Forms.TextBox tbHeader;
        private System.Windows.Forms.Button ButtonGCCollect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ToolStripMenuItem myProjectsToolStripMenuItem;
    }
}

