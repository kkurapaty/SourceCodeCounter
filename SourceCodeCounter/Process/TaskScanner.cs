using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SourceCodeCounter.Core;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Process
{
    public class TaskScanner
    {
        #region - Private Constants -
        private const int MaxNameLength = 50;
        private const string CHeaderFormatTabulation = "{0,-50}{1,10}{2,10}{3,10}{4,10}{5,10}";
        private const int LineLength = MaxNameLength + (5 * 10);
        private static readonly string Separator = new string('-', LineLength);

        private ITaskArguments _arguments;
        #endregion

        #region - Constructor -

        #endregion

        #region - Public Declarations -
        /// <summary>
        /// Starts the task and writes the results to the standard output stream.
        /// </summary>
        public bool Execute(ITaskArguments arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException("arguments");

            _arguments = arguments;

            Debug.Assert(_arguments.SourceHandler.FileCount > 0, "Error: No project files were specified.");
            try
            {
                var controller = new SourceController(_arguments.SourceHandler);
                // Subscribe for event notifications
                controller.ProcesNotify += OnProcesNotify;
                controller.ProcessInfoNotify += OnProcessInfoNotify;
                controller.ProcessStartNotify += OnProcessStartNotify;
                controller.ProcessCompleteNotify += OnProcessCompleteNotify;
                controller.ProcessExceptionNotify += OnProcessExceptionNotify;
                // Process Files Now
                controller.Process();
                // Show Results
                ShowResults();
                return true;
            }
            catch (InvalidFileException ex)
            {
                OnProcessExceptionNotify(this, new TaskExceptionEventArgs(ex));
            }
            return false;
        }

        public string GetAsXml()
        {
           return _arguments.SourceHandler.GetAsXml();
        }
        #endregion

        #region - Private Declarations -
        private void ShowResults()
        {
            if (_arguments.Output == null) return;
            
            var files = new List<SourceFile>(10);

            // Write initial headers
            if (_arguments.ShowFiles && !_arguments.ShowProjects)
                WriteHeader("Files");
            else if (!_arguments.ShowFiles && _arguments.ShowProjects)
                WriteHeader("Projects");

            if (_arguments.ShowProjects || _arguments.ShowFiles)
            {
                foreach (Project project in _arguments.SourceHandler.Projects.Items.Where(project => project.FileCount > 0).OrderBy(x => x.Name))
                {
                    files.Clear();
                    files.AddRange(project.Files);
                    files.Sort((file1, file2) => String.CompareOrdinal(file1.Name, file2.Name));

                    if (_arguments.ShowFiles)
                    {
                        // Write project header
                        if (_arguments.ShowProjects)
                        {
                            WriteHeader(project.ToString()); // Write project header
                            //WriteHeader(string.Format("{0} files({1})", project.Name, project.FileCount));
                        }

                        // Write counting results
                        foreach (SourceFile file in files)
                        {
                            WriteReport(file.Name, file.Report, _arguments.ShowPercentage);
                        }

                        // Write total report and group separator
                        if (_arguments.ShowProjects)
                        {
                            if (project.FileCount > 1)
                            {
                                WriteSeparator();
                                WriteReport(string.Format(" TOTAL ({0})", project.Name), project.Report, _arguments.ShowPercentage);
                            }
                            WriteNewLine();
                        }
                    }
                    else
                    {
                        // Show only projects without files
                        WriteReport(project.ToString(), project.Report, _arguments.ShowPercentage);
                    }
                }
                if (_arguments.ShowSummary && (_arguments.ShowProjects ^ _arguments.ShowFiles))
                    WriteNewLine();
            }

            // Write counting summary
            if (!_arguments.ShowSummary) return;
            if ((!_arguments.ShowFiles) && (!_arguments.ShowProjects))
            {
                WriteHeader("Summary");
            }
            else
            {
                WriteSeparator();
            }
            WriteReport(string.Format("Grand Total ({0} Projects)", _arguments.SourceHandler.Projects.Count), _arguments.SourceHandler.Report, _arguments.ShowPercentage);
        }

        private void WriteHeader(string title)
        {
            string header = string.Format(CHeaderFormatTabulation, title, "Code", "Comment", "Blank", "Mixed", "Total");
            if (_arguments.ShowFiles)
            {
                _arguments.Output.AppendLine(Separator);
                _arguments.Output.AppendLine(header);
                _arguments.Output.AppendLine(Separator);
            }
            else
            {
                _arguments.Output.AppendFormat("{0}------------\n", Separator);
                _arguments.Output.AppendFormat("{0}{1,10}\n", header, "Files");
                _arguments.Output.AppendFormat("{0}------------\n", Separator);
            }
        }

        private void WriteSeparator()
        {
            if (_arguments.ShowFiles)
            {
                _arguments.Output.AppendLine(Separator);
            }
            else
            {
                _arguments.Output.AppendFormat("{0}------------\n", Separator);  
            }
        }

        private void WriteNewLine()
        {
            _arguments.Output.AppendLine();
        }

        private void WriteReport(string name, SourceResult report, bool percentage)
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

            if (_arguments.ShowFiles)
                _arguments.Output.AppendLine(line);
            else
                _arguments.Output.AppendFormat("{0}{1,10}\n", line, report.TotalFiles.ToString("#,###"));

        }
        #endregion

        #region - Event Handlers -
        public event TaskNotifyHandler TaskNotify;
        protected virtual void OnProcesNotify(object sender, TaskEventArgs args)
        {
            TaskNotifyHandler handler = TaskNotify;
            if (handler != null) handler(sender, args);
        }

        public event TaskInfoNotifyHandler TaskInfoNotify;

        protected virtual void OnProcessInfoNotify(object sender, TaskInfoEventArgs args)
        {
            TaskInfoNotifyHandler handler = TaskInfoNotify;
            if (handler != null) handler(sender, args);
        }

        public event TaskStartNotifyHandler TaskStartNotify;

        protected virtual void OnProcessStartNotify(object sender, EventArgs args)
        {
            TaskStartNotifyHandler handler = TaskStartNotify;
            if (handler != null) handler(sender, args);
        }

        public event TaskCompleteNotifyHandler TaskCompleteNotify;

        protected virtual void OnProcessCompleteNotify(object sender, TaskCompleteEventArgs args)
        {
            TaskCompleteNotifyHandler handler = TaskCompleteNotify;
            if (handler != null) handler(sender, args);
        }

        public event TaskExceptionNotifyHandler TaskExceptionNotify;

        protected virtual void OnProcessExceptionNotify(object sender, TaskExceptionEventArgs args)
        {
            TaskExceptionNotifyHandler handler = TaskExceptionNotify;
            if (handler != null) handler(sender, args);
        }
        #endregion
    }


}