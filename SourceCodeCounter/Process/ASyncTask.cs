using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Collections.Generic;
using SourceCodeCounter.Common;
using SourceCodeCounter.Core;
using SourceCodeCounter.Interfaces;
using SourceCodeCounter.Parsers;

namespace SourceCodeCounter.Process
{
    internal class ASyncTask
    {
        #region - Private Properties -

        private ITaskArguments _taskArgs;
        private ProgressStatus _status = ProgressStatus.Idle;
        private bool _taskRunning;
        private readonly object _sync = new object();
        private AsyncContext _taskContext;

        private const int MaxNameLength = 50;
        private const string CHeaderFormatTabulation = "{0,-50}{1,10}{2,10}{3,10}{4,10}{5,10}";
        private const int LineLength = MaxNameLength + (5 * 10);
        private static readonly string Separator = new string('-', LineLength);
        private static int _progress;
        #endregion

        #region - Public Properties -

        public bool IsBusy
        {
            get { return _taskRunning; }
        }

        #endregion

        #region - EventHandlers & Delegates -

        public event AsyncCompletedEventHandler OnTaskCompleted;
        public event TaskProgressChangedEventHandler OnTaskProgressChanged;

        private delegate void TaskWorkerDelegate(ITaskArguments taskArguments, AsyncOperation asyncOperation, AsyncContext asyncContext, out bool cancelled);

        #endregion

        #region - Protected Virtual Methods -

        protected virtual void DoOnTaskCompleted(AsyncCompletedEventArgs e)
        {
            if (OnTaskCompleted != null)
                OnTaskCompleted(this, e);
        }

        protected virtual void DoOnTaskProgressChanged(TaskProgressChangedEventArgs eventArgs)
        {
            if (OnTaskProgressChanged != null)
                OnTaskProgressChanged(this, eventArgs);
        }

        #endregion

        #region - Private Declarations -

        private static ISourceResult ProcessSourceFile(SourceFile file)
        {
            BaseParser parser = ParserFactory.GetParser(file.Extension);
            if (parser == null) return file.Report;

            parser.Reset(); // Clear previous counting results
            try
            {
                using (var reader = new StreamReader(file.Path))
                {
                    // Parse each line from the file
                    while (!reader.EndOfStream)
                    {
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

        private int GetProgressPercent(int value, int ofValue)
        {
            try
            {
                return (int) (100 * (value / (double)ofValue));
            }
            catch (Exception)
            {
                return 100;
            }
        }
        #endregion

        #region - Public Declarations -
        public void StartAsync(ITaskArguments taskArguments)
        {
            TaskWorkerDelegate worker = StartProcessing;
            AsyncCallback completedCallback = TaskCompletedCallback;

            lock (_sync)
            {
                if (_taskRunning)
                    throw new InvalidOperationException("The control is currently busy.");

                AsyncOperation async = AsyncOperationManager.CreateOperation(null);
                var asyncContext = new AsyncContext();
                bool cancelled;
                worker.BeginInvoke(taskArguments, async, asyncContext, out cancelled, completedCallback, async);
                _taskRunning = true;
                _taskContext = asyncContext;
            }
        }
        public void CancelAsync()
        {
            lock (_sync)
            {
                if (_taskContext != null)
                    _taskContext.Cancel();
            }
        }
        #endregion

        #region - Protected Declarations -
       
        protected void WriteHeader(string title)
        {
            string header = string.Format(CHeaderFormatTabulation, title, "Code", "Comment", "Blank", "Mixed", "Total");
            if (_taskArgs.ShowFiles)
            {
                _taskArgs.Output.AppendLine(Separator);
                _taskArgs.Output.AppendLine(header);
                _taskArgs.Output.AppendLine(Separator);
            }
            else
            {
                _taskArgs.Output.AppendFormat("{0}------------\n", Separator);
                _taskArgs.Output.AppendFormat("{0}{1,10}\n", header, "Files");
                _taskArgs.Output.AppendFormat("{0}------------\n", Separator);
            }
        }

        protected void WriteSeparator()
        {
            if (_taskArgs.ShowFiles)
            {
                _taskArgs.Output.AppendLine(Separator);
            }
            else
            {
                _taskArgs.Output.AppendFormat("{0}------------\n", Separator);
            }
        }

        protected void WriteNewLine()
        {
            _taskArgs.Output.AppendLine();
        }

        protected void WriteReport(string name, ISourceResult report, bool percentage)
        {
            if (name != null && name.Length > MaxNameLength)
                name = name.Substring(0, MaxNameLength - 3) + "...";

            //var filePercent = (_arguments.SourceHandler.Report.TotalLines != 0) ? ((float)report.TotalLines / _arguments.SourceHandler.Report.TotalLines * 100):0.00F;
            string line = percentage
                              ? string.Format(CHeaderFormatTabulation, name,
                                              string.Format("{0:00}%", report.PercentageOfCodeLines),
                                              string.Format("{0:00}%", report.PercentageOfCommentLines),
                                              string.Format("{0:00}%", report.PercentageOfBlankLines),
                                              string.Format("{0:00}%", report.PercentageOfMixedLines),
                                              report.TotalLines.ToString("#,###"))
                              : string.Format(CHeaderFormatTabulation, name,
                                              report.CodeLines.ToString("#,###"),
                                              report.CommentLines.ToString("#,###"),
                                              report.BlankLines.ToString("#,###"),
                                              report.MixedLines.ToString("#,###"),
                                              report.TotalLines.ToString("#,###"));

            if (_taskArgs.ShowFiles)
                _taskArgs.Output.AppendLine(line);
            else
                _taskArgs.Output.AppendFormat("{0}{1,10}\n", line, report.TotalFiles.ToString("#,###"));

        }
        #endregion

        #region - ASynchronous Operations -

        private void StartProcessing(ITaskArguments taskArguments, AsyncOperation asyncOperation, AsyncContext asyncContext, out bool cancelled)
        {
            if ((taskArguments == null) || (taskArguments.SourceHandler == null))
            {
                cancelled = true;
                return;
            }

            _taskArgs = taskArguments;
            _status = ProgressStatus.Started;
            //Debug.Assert(_taskArgs.SourceHandler.FileCount > 0, "Error: No project files were specified.");

            int totalLines = 0;
            int totalCodeLines = 0;
            int totalCommentLines = 0;
            int totalBlankLines = 0;
            int totalFileCount = 0;
            int projectFilesCount = _taskArgs.SourceHandler.Projects.Items.Where(x => x.FileCount > 0).Sum(x => x.FileCount) + 1;

            _progress = GetProgressPercent(1, projectFilesCount);
            _status = ProgressStatus.ProcessingProjects;

            string statusText = string.Format("Projects: {0}", projectFilesCount);
            asyncOperation.Post(e => DoOnTaskProgressChanged((TaskProgressChangedEventArgs)e),
                                new TaskProgressChangedEventArgs(_status, statusText, _progress, null));
            //Thread.Sleep(5);

            #region // Process each project

            foreach (Project project in _taskArgs.SourceHandler.Projects.Items)
            {
                int projectTotalLines = 0;
                int projectCodeLines = 0;
                int projectCommentLines = 0;
                int projectBlankLines = 0;
                int projectFileCount = 0;

                // Notify Project Process
                _progress = GetProgressPercent(totalFileCount, projectFilesCount);
                statusText = project.Name;
                asyncOperation.Post(e => DoOnTaskProgressChanged((TaskProgressChangedEventArgs)e),
                                    new TaskProgressChangedEventArgs(_status, statusText, _progress, null));
                Thread.Sleep(5);

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
                    _status = ProgressStatus.ProcessingFiles;
                    _progress = GetProgressPercent(++projectFileCount, filesInProject);
                    statusText = file.Name;
                    asyncOperation.Post(e => DoOnTaskProgressChanged((TaskProgressChangedEventArgs)e),
                                        new TaskProgressChangedEventArgs(_status, statusText, _progress, null));

                    if (asyncContext.IsCancelling)
                    {
                        cancelled = true;
                        _status = ProgressStatus.Stopped;
                        return;
                    }
                    //Thread.Sleep(10);
                }

                #endregion

                // Create report object for project
                project.Report = new SourceResult(projectTotalLines, projectCodeLines, projectCommentLines,
                                                  projectBlankLines, projectFileCount);

                totalLines += projectTotalLines;
                totalCodeLines += projectCodeLines;
                totalCommentLines += projectCommentLines;
                totalBlankLines += projectBlankLines;
                totalFileCount += projectFileCount;

                statusText = project.Name;
                _progress = GetProgressPercent(totalFileCount, projectFilesCount);
                asyncOperation.Post(e => DoOnTaskProgressChanged((TaskProgressChangedEventArgs)e),
                                    new TaskProgressChangedEventArgs(_status, statusText, _progress, null));
                Thread.Sleep(5);
            }

            #endregion

            #region // Create summary report
            _taskArgs.SourceHandler.Report = new SourceResult(totalLines, totalCodeLines, totalCommentLines, totalBlankLines, totalFileCount);
            #endregion

            // Prepare Output
            PrepareResults(asyncOperation, asyncContext, out cancelled);

            // Set Completed
            _status = ProgressStatus.Completed;
        }
        private void PrepareResults(AsyncOperation asyncOperation, AsyncContext asyncContext, out bool cancelled)
        {
            cancelled = false;

            if ((_taskArgs == null) || (_taskArgs.Output == null))
            {
                cancelled = true;
                return;
            }
            #region // Send event that we are processing ...

            _progress++;
            _status = ProgressStatus.PreparingOutput;
            string statusText = "Preparing output, please wait ...";
            asyncOperation.Post(e => DoOnTaskProgressChanged((TaskProgressChangedEventArgs)e), new TaskProgressChangedEventArgs(_status, statusText, _progress, null));
            #endregion

            var files = new List<SourceFile>(10);

            #region // Write initial headers
            if (_taskArgs.ShowFiles && !_taskArgs.ShowProjects)
                WriteHeader("Files");
            else if (!_taskArgs.ShowFiles && _taskArgs.ShowProjects)
                WriteHeader("Projects");
            #endregion

            #region // Show Files / Projects
            if (_taskArgs.ShowProjects || _taskArgs.ShowFiles)
            {
                int projectsCount = _taskArgs.SourceHandler.Projects.Items.Count(project => project.FileCount > 0);
                int projectCounter = 0;
                foreach (Project project in _taskArgs.SourceHandler.Projects.Items.Where(project => project.FileCount > 0).OrderBy(x => x.Name))
                {
                    files.Clear();
                    files.AddRange(project.Files);
                    files.Sort((file1, file2) => String.CompareOrdinal(file1.Name, file2.Name));
                    _progress = GetProgressPercent(++projectCounter, projectsCount);
                    _status = ProgressStatus.PreparingOutput;

                    statusText = project.Name;
                    asyncOperation.Post(e => DoOnTaskProgressChanged((TaskProgressChangedEventArgs)e), new TaskProgressChangedEventArgs(_status, statusText, _progress, null));
                    if (asyncContext.IsCancelling)
                    {
                        cancelled = true;
                        _status = ProgressStatus.Stopped;
                        return;
                    }
                    if (_taskArgs.ShowFiles)
                    {
                        // Write project header
                        if (_taskArgs.ShowProjects)
                        {
                            WriteHeader(project.ToString()); // Write project header
                            //WriteHeader(string.Format("{0} files({1})", project.Name, project.FileCount));
                        }

                        // Write counting results
                        foreach (SourceFile file in files)
                        {
                            WriteReport(file.Name, file.Report, _taskArgs.ShowPercentage);
                        }

                        // Write total report and group separator
                        if (_taskArgs.ShowProjects)
                        {
                            if (project.FileCount > 1)
                            {
                                WriteSeparator();
                                WriteReport(string.Format(" TOTAL ({0})", project.Name), project.Report, _taskArgs.ShowPercentage);
                            }
                            WriteNewLine();
                        }
                    }
                    else
                    {
                        // Show only projects without files
                        WriteReport(project.ToString(), project.Report, _taskArgs.ShowPercentage);
                    }
                }
                if (_taskArgs.ShowSummary && (_taskArgs.ShowProjects ^ _taskArgs.ShowFiles))
                    WriteNewLine();
            }
            #endregion

            #region // Show Summary
            if (!_taskArgs.ShowSummary) return;
            if ((!_taskArgs.ShowFiles) && (!_taskArgs.ShowProjects))
            {
                WriteHeader("Summary");
            }
            else
            {
                WriteSeparator();
            }
            WriteReport(string.Format("Grand Total ({0} Projects)", _taskArgs.SourceHandler.Projects.Count), _taskArgs.SourceHandler.Report, _taskArgs.ShowPercentage);
            #endregion

            // Set Completed
            _status = ProgressStatus.Completed;
        }

        private void TaskCompletedCallback(IAsyncResult asyncResult)
        {
            // Retrieve the delegate.
            var result = (AsyncResult)asyncResult;
            // get the original worker delegate and the AsyncOperation instance
            var worker = (TaskWorkerDelegate)result.AsyncDelegate;
            var async = (AsyncOperation)asyncResult.AsyncState;
            bool cancelled;

            // finish the asynchronous operation
            worker.EndInvoke(out cancelled, asyncResult);

            // clear the running task flag
            lock (_sync)
            {
                _taskRunning = false;
                _taskContext = null;
            }

            // raise the completed event
            var completedArgs = new AsyncCompletedEventArgs(null, cancelled, null);
            async.PostOperationCompleted(e => DoOnTaskCompleted((AsyncCompletedEventArgs)e), completedArgs);
        }
        #endregion
    }

    internal class AsyncContext
    {
        #region - Private Declarations -
        private readonly object _sync = new object();
        private bool _isCancelling;
        #endregion

        #region - Public Declarations -
        public bool IsCancelling
        {
            get
            {
                lock (_sync) { return _isCancelling; }
            }
        }
        public void Cancel()
        {
            lock (_sync) { _isCancelling = true; }
        }
        #endregion
    }
}
