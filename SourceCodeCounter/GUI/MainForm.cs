using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SourceCodeCounter.Common;
using SourceCodeCounter.Core;
using SourceCodeCounter.GUI.Contols;
using SourceCodeCounter.Interfaces;
using SourceCodeCounter.Process;
using SourceCodeCounter.Properties;

namespace SourceCodeCounter.GUI
{
    public partial class MainForm : Form
    {
        #region - Constructor -
        public MainForm()
        {
            InitializeComponent();
            Initialise();
        }
        #endregion

        #region - Private Properties -
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private ASyncTaskController _aSyncTaskController;
        private ITaskArguments _taskArguments;
        private readonly ProjectControl _projectControl = new ProjectControl();
        private readonly SourceControl _sourceControl = new SourceControl();
        private VerticalTabControl _tabControlContent;
        private SampleGarbageCollector _gcCollector;
        #endregion

        #region - Private Declarations -
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_aSyncTaskController.IsRunning) StopASyncProcess();
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            Scan();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopASyncProcess();
        }

        private void checkFreezeHeader_CheckedChanged(object sender, EventArgs e)
        {
            tbHeader.Visible = checkFreezeHeader.Checked;
        }

        private void AddProject(string projTitle, string projPath, bool includeSubDir)
        {
            var li = new ListViewItem(projTitle);
            li.SubItems.Add(projPath);
            li.SubItems.Add(includeSubDir ? "yes" : "no");
            lvProjects.Items.Add(li);
            SetButtons();
        }

        private void SetButtons()
        {
            bool hasProjects = (lvProjects.Items.Count > 0);
            bool isProjectSelected = (lvProjects.SelectedItems.Count > 0);
            btnScan.Enabled = hasProjects;
            mniClearItems.Enabled = hasProjects;
            mniEditItem.Enabled = isProjectSelected;
            mniRemoveItem.Enabled = isProjectSelected;
            mniScanSelected.Enabled = isProjectSelected;
            tbHeader.Visible = checkFreezeHeader.Checked;
        }

        private void Initialise()
        {
            SetButtons();
            InitializeController();
            
            _gcCollector = new SampleGarbageCollector(new RichTextLogger(rtDebug));

            InitialiseVertiacalTabControl();
            _projectControl.Refresh(_taskArguments);
            _sourceControl.Refresh(_taskArguments);
        }

        private void InitialiseVertiacalTabControl()
        {
            // Initialize content/index tab control
            _tabControlContent = new VerticalTabControl
                {
                    Vertical = false,
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    BorderColor = Color.FromArgb(191, 191, 191),
                    Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(117, 117, 117)
                };

            // 1. Add Contents page
            _tabControlContent.TabPages.Add("Output");
            _tabControlContent.TabPages[0].Controls.Add(tbHeader);
            tbHeader.Dock = DockStyle.Top;
            _tabControlContent.TabPages[0].Controls.Add(rtResults);
            rtResults.Dock = DockStyle.Fill;

            // 2. Add Prjects page
            _tabControlContent.TabPages.Add("Projects");
            _tabControlContent.TabPages[1].Controls.Add(_projectControl);
            _projectControl.Dock = DockStyle.Fill;

            // 3. Add Source Lines page
            _tabControlContent.TabPages.Add("Source");
            _tabControlContent.TabPages[2].Controls.Add(_sourceControl);
            _sourceControl.Dock = DockStyle.Fill;

            // 4. Add Debug page
            _tabControlContent.TabPages.Add("Debug");
            _tabControlContent.TabPages[3].Controls.Add(rtDebug);
            rtDebug.Dock = DockStyle.Fill;

            // Add event handler when selected tab changes
            //tabControlContent.SelectedIndexChanged += new EventHandler(this.tabControlContent_SelectedIndexChanged);

            // Add tab control into the panel
            panelTabContent.Controls.Add(_tabControlContent);
        }

        private void Processing(bool processing)
        {
            btnScan.Visible = !processing;
            btnStop.Visible = processing;

            statusPanel1.Text = processing ? Resources.Resource_PleaseWait : Resources.Resource_ScanComplete;
            statusPanel1.Invalidate();
            progressBar.Invalidate();

            if (processing)
            {
                _stopWatch.Start();
                // Set busy Cursor
                Cursor = Cursors.WaitCursor;
            }
            else
            {
                _stopWatch.Stop();
                // Set Process Info
                statusPanel2.Text = string.Format("Processed in {0}.", _stopWatch.Elapsed.AsString());
                //String.Format("Processed in {0:00}:{1:00}:{2:00}.{3:00}", stopWatch.Elapsed.Hours, stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds / 10);
                statusPanel2.Invalidate();
                // Set default cursor
                Cursor = Cursors.Default;
            }
        }
        
        #endregion

        #region - Public Declarations -

        public void Reset()
        {
            chkFiles.CheckState = CheckState.Unchecked;
            chkProjects.CheckState = CheckState.Unchecked;
            chkSummary.CheckState = CheckState.Checked;
            chkPercentage.CheckState = CheckState.Unchecked;
            lvProjects.Items.Clear();
            rtResults.Clear();
            rtDebug.Clear();
            _projectControl.Clear();
            _sourceControl.Clear();
            SetButtons();
        }

        public void Scan()
        {
            if ((lvProjects.Items.Count > 0) && (!_aSyncTaskController.IsRunning))
            {
                if (chkClearResults.Checked)
                {
                    rtResults.Clear();
                    rtDebug.Clear();
                }
                
                try
                {
                    _taskArguments = new TaskArguments(chkPercentage.Checked, chkFiles.Checked, chkProjects.Checked, chkSummary.Checked);
                    _taskArguments.ProcessExceptionNotify += DoOnTaskExceptionNotify;
                    statusPanel2.Text = Resources.Resource_PleaseWaitPreparing;
                    foreach (ListViewItem lvItem in lvProjects.Items)
                    {                        
                        _taskArguments.AddProject(lvItem.SubItems[0].Text, lvItem.SubItems[1].Text, (@"yes" == lvItem.SubItems[2].Text));
                    }
                    statusPanel2.Text = Resources.Resource_PleaseWaitScanning;
                    StartASyncProcess();
                }
                catch (Exception e) 
                {
                    rtDebug.LogException(e);
                    Processing(false);
                }  
            }
        }

        public void ScanSelectedProject()
        {
            if ((lvProjects.SelectedItems.Count <= 0)) return;
            try
            {
                var taskArguments = new TaskArguments(chkPercentage.Checked, chkFiles.Checked, chkProjects.Checked, chkSummary.Checked);
                taskArguments.ProcessExceptionNotify += DoOnTaskExceptionNotify;
                statusPanel2.Text = Resources.Resource_PleaseWaitAnalysing;
                foreach (ListViewItem lvItem in lvProjects.SelectedItems)
                {
                    taskArguments.AddProject(lvItem.SubItems[0].Text, lvItem.SubItems[1].Text, (@"yes" == lvItem.SubItems[2].Text));
                }
                
                statusPanel2.Text = Resources.Resource_PleaseWaitScanning;
                HelperClass.ShowScanDialog(taskArguments);
                statusPanel2.Text = Resources.Resource_ScanComplete;
            }
            catch (Exception e)
            {
                rtDebug.LogException(e);
                Processing(false);
            }
        }

        public void RefreshCharts()
        {
            if (_projectControl != null)
                _projectControl.Refresh(_taskArguments);

            if (_sourceControl != null)
                _sourceControl.Refresh(_taskArguments);
        }
        #endregion

        #region - Context Menu Handler -
        private void mniAddItem_Click(object sender, EventArgs e)
        {
            string projTitle = string.Format("Project {0}", lvProjects.Items.Count+1);
            string projPath = string.Empty;
            bool includeSubdir = false;
            if (HelperClass.ShowProjectSelection("Add", ref projTitle, ref projPath, ref includeSubdir))
            {
                AddProject(projTitle, projPath, includeSubdir);
            }
            SetButtons();
        }

        private void mniEditItem_Click(object sender, EventArgs e)
        {
            if (lvProjects.SelectedItems.Count > 0)
            {
                string projTitle = lvProjects.SelectedItems[0].Text;
                string projPath = lvProjects.SelectedItems[0].SubItems[1].Text;
                string boolStr = lvProjects.SelectedItems[0].SubItems[2].Text;
                bool includeSubdir = ("yes" == boolStr );

                if (HelperClass.ShowProjectSelection("Edit", ref projTitle, ref projPath, ref includeSubdir))
                {
                    lvProjects.SelectedItems[0].Text = projTitle;
                    lvProjects.SelectedItems[0].SubItems[1].Text = projPath;
                    lvProjects.SelectedItems[0].SubItems[2].Text = includeSubdir ? "yes" : "no";
                }
            }
            SetButtons();
        }

        private void mniRemoveItem_Click(object sender, EventArgs e)
        {
            // Remove all selected items from list
            while (lvProjects.SelectedItems.Count > 0)
            {
                lvProjects.SelectedItems[0].Remove();
            }
            SetButtons();
        }

        private void mniClearItems_Click(object sender, EventArgs e)
        {
            lvProjects.Items.Clear();
            SetButtons();
        }

        private void mniTPlusProjects_Click(object sender, EventArgs e)
        {
            // Tempest Projects
            AddProject("Tempest+ Client",  @"C:\MSDE\Dev\Commodities\tempest\Tempestplus2\dev\client\*.pas", true);
            AddProject("Tempest+ Servers", @"C:\MSDE\Dev\Commodities\tempest\Tempestplus2\dev\server\*.pas", true);
            AddProject("Tempest+ Shared",  @"C:\MSDE\Dev\Commodities\tempest\Tempestplus2\dev\shared\*.pas", true);

            // Tempest Components
            AddProject("TPlus DEV Components", @"C:\MSDE\Dev\Commodities\tempest\d_components\dev\*.pas", true);
            AddProject("TPlus SQLDirect Comps", @"C:\MSDE\Dev\Commodities\tempest\d_components\devSQLDirect\*.pas", true);

            // Trade Uploader
            AddProject("Trade Uploader", @"C:\MSDE\Dev\Commodities\tempest\TradeUploader\dev\TradeUploader.sln", true);

            // Tempest Manager
            AddProject("Tempest Manager", @"C:\MSDE\Dev\Commodities\tempest\TempestManSD\dev\src\TempestMan.dpr", true);

            // Tempest Schema
            AddProject("Tempest Schema", @"C:\MSDE\Dev\Commodities\tempest\schema\dev\*.sql", true);

        }

        private void myProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Delphi Projects
            AddProject("Delphi Projects", @"C:\Users\kuraki\kuraki\Examples\Delphi\*.dpr", true);

            // .Net Projects
            AddProject(".Net Projects", @"C:\Users\kuraki\kuraki\Examples\CSharp\*.sln", true);
        }

        private void mniScanSelectedProject_Click(object sender, EventArgs e)
        {
            if (lvProjects.SelectedItems.Count > 0)
            {
                ScanSelectedProject();
            }
        }

        private void lvProjects_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            SetButtons();
        }
        #endregion

        #region - Event Subscribers -
        protected void DoOnTaskExceptionNotify(object sender, TaskExceptionEventArgs args)
        {
            if (args != null) rtDebug.LogException(args.Exception);
        }
        #endregion

        #region - ASyncOperation Events -
        void InitializeController()
        {
            _aSyncTaskController = new ASyncTaskController();
            _aSyncTaskController.OnCompleted += OnAsyncProcessCompleted;
            _aSyncTaskController.OnProgressChanged += OnAsyncProcessASyncTaskChanged;
        }
        void StartASyncProcess()
        {
            if (_aSyncTaskController == null) return;
            _aSyncTaskController.Start(_taskArguments);
            Processing(true);
        }
        void StopASyncProcess()
        {
            if (_aSyncTaskController == null) return;
            _aSyncTaskController.Stop();
            SetButtons();
        }
        void OnAsyncProcessCompleted(object sender, AsyncCompletedEventArgs e)
        {
            statusPanel1.Text = e.Cancelled ? "Cancelled" : "Completed";
            if (!e.Cancelled)
            {
                rtResults.AppendText(_taskArguments.Output.ToString());
                RefreshCharts();
            }
            Processing(false);
        }
        void OnAsyncProcessASyncTaskChanged(object sender, TaskProgressChangedEventArgs progressArgs)
        {
            statusPanel2.Text = String.Format("{0} : {1}", progressArgs.Status, progressArgs.Result);
            progressBar.Value = progressArgs.ProgressPercentage;
            progressBar.Invalidate();
        }
        #endregion

        #region - About Box -
        private void btnAbout_Click(object sender, EventArgs e)
        {
            HelperClass.ShowAboutDialog();
        }
        #endregion

        #region - Garbage Collector -
        private void ButtonGCCollect_Click(object sender, EventArgs e)
        {
            if (_gcCollector != null)
            {
                dynamic dynVar = null;
                if (radioButton1.Checked) dynVar = _stopWatch;
                if (radioButton2.Checked) dynVar = _aSyncTaskController;
                if (radioButton3.Checked) dynVar = _taskArguments;
                if (radioButton4.Checked) dynVar = _tabControlContent;
                if (radioButton5.Checked) dynVar = this;
                if (radioButton6.Checked) dynVar = null;
                
                _gcCollector.Execute(dynVar);
            }
        }
        #endregion

    }
}
