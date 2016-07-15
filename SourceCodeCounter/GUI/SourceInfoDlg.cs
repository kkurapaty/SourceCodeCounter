using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SourceCodeCounter.Common;
using SourceCodeCounter.Core;
using SourceCodeCounter.Interfaces;
using SourceCodeCounter.Parsers;
using SourceCodeCounter.Process;
using SourceCodeCounter.Properties;

namespace SourceCodeCounter.GUI
{
    public partial class SourceInfoDlg : Form
    {
        #region - Constructor
        public SourceInfoDlg(ITaskArguments taskArguments)
        {
            InitializeComponent();
            _taskArguments = taskArguments;
            SetButtons(false);
        }
        #endregion
        
        #region - Form Event Handlers -
        private void SourceInfoDlg_Load(object sender, EventArgs e)
        {
            StartScan();
        }
        private void SourceInfoDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((bwTask.WorkerSupportsCancellation) && (bwTask.IsBusy))
            {
                bwTask.CancelAsync();
                e.Cancel = true;
            }

            if (!bwTask.IsBusy) e.Cancel = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            StopScan();

            if (!bwTask.IsBusy) Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            StartScan();
        }
        #endregion

        #region - Private Declarations -
        private ITaskArguments _taskArguments;

        private void SetButtons(bool isRunning)
        {
            OkButton.Enabled = !isRunning;
            CancelButton.Text = isRunning ? "&Cancel" : "&Close";
            lblCurrentLine.Text = (!isRunning) ? "Mixed lines:" : "Current line:";
        }
        private int GetProgressPercent(int value, int ofValue)
        {
            try
            {
                return (int)(100 * (value / (double)ofValue));
            }
            catch (Exception)
            {
                return 100;
            }
        }
        private ISourceResult ProcessSourceFile(SourceFile file)
        {
            BaseParser parser = ParserFactory.GetParser(file.Extension);
            if (parser == null) return file.Report;
            int lineNum = 0;
            parser.Reset(); // Clear previous counting results
            try
            {
                using (var reader = new StreamReader(file.Path))
                {
                    // Parse each line from the file
                    while (!reader.EndOfStream)
                    {
                        DoCurrentLineNotify(++lineNum);
                        string line = reader.ReadLine();
                        parser.ParseNextLine(line);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new InvalidFileException(file, "Input file '" + file.Path + "' could not be found.", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new InvalidFileException(file, "Input file '" + file.Path + "' could not be found.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new InvalidFileException(file, "Input file '" + file.Path + "' could not be opened.", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidFileException(file, "An error occured reading the file '" + file.Path + "'.", ex);
            }

            return parser.GenerateResult();
        }
        #endregion

        #region - Internal Declarations -

        internal void StartScan()
        {
            if (!bwTask.IsBusy)
            {
                SetButtons(true);
                bwTask.RunWorkerAsync();
            }
        }
        internal void StopScan()
        {
            if ((bwTask.WorkerSupportsCancellation) && (bwTask.IsBusy))
                bwTask.CancelAsync();
        }
        #endregion

        #region - Event Subscribers -

        protected void DoTaskInfoNotify(TaskInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.Result != null)
                {
                    tbBlankLines.Text = args.Result.BlankLines.ToString("#,###");
                    tbCodeLines.Text = args.Result.CodeLines.ToString("#,###");
                    tbComments.Text = args.Result.CommentLines.ToString("#,###");
                    tbTotalLines.Text = args.Result.TotalLines.ToString("#,###");
                }
                tbResults.Text = args.FileName;
                tbProject.Text = args.ProjectName;
            }
        }

        protected void DoCurrentLineNotify(int lineNumber)
        {
            tbCurrentLine.InvokeIfRequired(x => { x.Text = lineNumber.ToString("#,###"); });
        }

        #endregion

        #region - BackgroundWorker Events -

        private void OnBackgroundWorkerTaskDoWork(object sender, DoWorkEventArgs e)
        {
            //var backgroundWorker = sender as BackgroundWorker;
            Debug.Assert(bwTask != null, "BackgroundWorker is not assigned!");
            if (_taskArguments == null) return;

            if ((_taskArguments != null) && (_taskArguments.SourceHandler == null)) return;
            
            e.Cancel = false;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var sourceHandler = _taskArguments.SourceHandler;
            sourceHandler.Projects.Sort();
            int projectFilesCount = sourceHandler.Projects.Items.Where(x => x.FileCount > 0).Sum(x => x.FileCount) + 1;
            int progress;

            #region // Local Variables

            int totalLines = 0;
            int totalCodeLines = 0;
            int totalCommentLines = 0;
            int totalBlankLines = 0;
            int totalFileCount = 0;

            #endregion

            #region // Process each project

            foreach (Project project in sourceHandler.Projects.Items)
            {
                int projectTotalLines = 0;
                int projectCodeLines = 0;
                int projectCommentLines = 0;
                int projectBlankLines = 0;
                int projectFileCount = 0;

                #region // Notify Project Process
                progress = GetProgressPercent(totalFileCount, projectFilesCount);
                bwTask.ReportProgress(progress, new TaskInfoEventArgs(project.Name, string.Empty, project.Report));
                if (bwTask.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                #endregion

                #region // Count each file

                int filesInProject = project.FileCount;
                foreach (SourceFile file in project.Files)
                {
                    // Process Source file
                    file.Report = ProcessSourceFile(file);

                    // Create report object for file
                    projectTotalLines += file.Report.TotalLines;
                    projectCodeLines += file.Report.CodeLines;
                    projectCommentLines += file.Report.CommentLines;
                    projectBlankLines += file.Report.BlankLines;

                    // Notify Project Process
                    progress = GetProgressPercent(++projectFileCount, filesInProject);
                    project.Report = new SourceResult(projectTotalLines, projectCodeLines, projectCommentLines, projectBlankLines, projectFileCount);
                    bwTask.ReportProgress(progress, new TaskInfoEventArgs(project.Name, file.Name, project.Report));
                    if (bwTask.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    //Thread.Sleep(10);
                }

                #endregion

                #region // Create report object for project

                project.Report = new SourceResult(projectTotalLines, projectCodeLines, projectCommentLines, projectBlankLines, projectFileCount);

                totalLines += projectTotalLines;
                totalCodeLines += projectCodeLines;
                totalCommentLines += projectCommentLines;
                totalBlankLines += projectBlankLines;
                totalFileCount += projectFileCount;

                progress = GetProgressPercent(totalFileCount, projectFilesCount);
                bwTask.ReportProgress(progress, new TaskInfoEventArgs(project.Name, string.Empty, project.Report));

                #endregion
            }
            #endregion

            #region // Report Summary
            sourceHandler.Report = new SourceResult(totalLines, totalCodeLines, totalCommentLines, totalBlankLines, totalFileCount);
            progress = 100;
            bwTask.ReportProgress(progress, new TaskInfoEventArgs(sourceHandler.Projects.Items[0].Name, string.Empty, sourceHandler.Report));
            // Set Process Info
            stopWatch.Stop();
            e.Cancel = false;
            e.Result = string.Format("in {0}.", stopWatch.Elapsed.AsString());            
            #endregion
        }

        private void OnBackgroundWorkerTaskProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = (e.ProgressPercentage > 100) ? 0 : e.ProgressPercentage;
            
            if (e.UserState != null)
            {
                var args = (TaskInfoEventArgs) e.UserState;
                
                tbProject.Text = args.ProjectName;
                tbResults.Text = args.FileName;
                if (args.Result != null)
                {
                    tbBlankLines.Text = args.Result.BlankLines.ToString("#,###");
                    tbCodeLines.Text = args.Result.CodeLines.ToString("#,###");
                    tbComments.Text = args.Result.CommentLines.ToString("#,###");
                    tbTotalLines.Text = args.Result.TotalLines.ToString("#,###");
                    tbCurrentLine.Text = args.Result.MixedLines.ToString("#,###");
                }
            }
        }

        private void OnBackgroundWorkerTaskCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string processTime = e.Result != null ? e.Result.ToString() : string.Empty;
            tbResults.Text = string.Format("{0} {1}", e.Cancelled ? "Canceled" : "Completed", processTime);
            SetButtons(false);
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, Resources.Resource_ProjectScanner, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
