using System;
using System.IO;
using System.Text;
using SourceCodeCounter.Common;
using SourceCodeCounter.Core;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Process
{

    internal class TaskArguments : ITaskArguments
    {
        #region - Private Declarations -

        readonly SourceFileHandler _sourceFileHandler;
        #endregion

        #region - Constructor -
        public TaskArguments(bool showPercent, bool showFiles, bool showProjects, bool showSummary)
        {
            ShowPercentage = showPercent;
            ShowFiles = showFiles;
            ShowProjects = showProjects;
            ShowSummary = showSummary;
            
            Output = new StringBuilder();
            _sourceFileHandler = new SourceFileHandler();
        }
        #endregion

        #region - Public Declarations -
        public ISourceHandler SourceHandler
        {
            get { return _sourceFileHandler; }
        }

        public StringBuilder Output { get; set; }

        public void AddProject(string projectTitle, string projectPath, bool includeSubDir)
        {
            try
            {
                if (!((string.IsNullOrEmpty(projectTitle) || string.IsNullOrEmpty(projectPath))))
                {
                    string extension = Path.GetExtension(projectPath);

                    if (HelperClass.IsValidProjectFile(extension))
                    {
                        _sourceFileHandler.AddProject(projectPath);
                    }
                    else if (HelperClass.IsDotNetSolutionFile(extension))
                    {
                        _sourceFileHandler.AddSolution(projectPath);
                    }
                    else
                    {
                        if (includeSubDir)
                        {
                            _sourceFileHandler.AddFilesRecursively(projectPath, projectTitle);
                        }
                        else
                        {
                            _sourceFileHandler.AddFile(projectPath, projectTitle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnProcessExceptionNotify(this, new TaskExceptionEventArgs(ex));
            }
        }

        public void AddExcludeOption(string param)
        {
            try
            {
                _sourceFileHandler.AddExludePattern(param);
                // Remove files matching the exclude patterns
                _sourceFileHandler.ValidateExcludePatterns();
            }
            catch (Exception ex)
            {
                OnProcessExceptionNotify(this, new TaskExceptionEventArgs(ex));
            }
        }

        public bool ShowFiles { get; private set; }

        public bool ShowProjects { get; private set; }

        public bool ShowSummary { get; private set; }

        public bool ShowPercentage { get; private set; }

        public void ClearProjects()
        {
            _sourceFileHandler.Clear();
        }
        #endregion

        #region - Event Handlers -
        public event TaskExceptionNotifyHandler ProcessExceptionNotify;

        protected virtual void OnProcessExceptionNotify(object sender, TaskExceptionEventArgs args)
        {
            TaskExceptionNotifyHandler handler = ProcessExceptionNotify;
            if (handler != null) handler(sender, args);
        }
        #endregion
    }
}
