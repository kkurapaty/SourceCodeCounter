using System;
using System.IO;
using SourceCodeCounter.Interfaces;
using SourceCodeCounter.Parsers;
using SourceCodeCounter.Process;

namespace SourceCodeCounter.Core
{
    /// <summary>
    /// Represents a counter class for counting the source lines and generating 
    /// report informations.
    /// </summary>
    public class SourceController
    {
        #region - Constructor -
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceController"/> class 
        /// with the specified file set.
        /// </summary>
        /// <param name="sourceHandler">A <see cref="ISourceHandler"/> object that 
        /// contains essential project and file informations.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sourceHandler"/> is null.
        /// </exception>
        public SourceController(ISourceHandler sourceHandler)
        {
            if (sourceHandler == null)
                throw new ArgumentNullException("sourceHandler");

            _sourceHandler = sourceHandler;
        }
        #endregion

        #region - Private Declarations -
        readonly ISourceHandler _sourceHandler;
        #endregion
        
        #region - Public Declarations -
        /// <summary>
        /// Counts the required statistical data about the files and projects, and 
        /// generates <see cref="SourceResult"/> objects from the results.
        /// </summary>
        /// <exception cref="InvalidFileException">
        /// A source file is missing or has invalid extension.
        /// </exception>
        public void Process()
        {
            bool bSuccess = false;
            OnProcessStartNotify();
            try
            {
                int totalLines = 0;
                int totalCodeLines = 0;
                int totalCommentLines = 0;
                int totalBlankLines = 0;
                int totalFileCount = 0;
                
                // Count each project
                foreach (Project project in _sourceHandler.Projects.Items)
                {
                    int projectTotalLines = 0;
                    int projectCodeLines = 0;
                    int projectCommentLines = 0;
                    int projectBlankLines = 0;
                    int projectFileCount = 0;

                    // Notify Project Process
                    OnProcesNotify(this, new TaskEventArgs(project.Name));
                    // Count each file
                    foreach (SourceFile file in project.Files)
                    {
                        // Notify Project Process
                        OnProcesNotify(this, new TaskEventArgs(file.Name));

                        file.Report = ProcessSourceFile(file);

                        // Notify Output for each file
                        OnProcessInfoNotify(this, new TaskInfoEventArgs(project.Name, file.Name, file.Report));

                        // Create report object for file
                        projectTotalLines += file.Report.TotalLines;
                        projectCodeLines += file.Report.CodeLines;
                        projectCommentLines += file.Report.CommentLines;
                        projectBlankLines += file.Report.BlankLines;
                        ++projectFileCount;
                    }

                    // Create report object for project
                    project.Report = new SourceResult(projectTotalLines, projectCodeLines, projectCommentLines, projectBlankLines, projectFileCount);

                    totalLines += projectTotalLines;
                    totalCodeLines += projectCodeLines;
                    totalCommentLines += projectCommentLines;
                    totalBlankLines += projectBlankLines;
                    totalFileCount += projectFileCount;
                }

                // Create summary report
                _sourceHandler.Report = new SourceResult(totalLines, totalCodeLines, totalCommentLines, totalBlankLines, totalFileCount);
                bSuccess = true;
            }
            catch (Exception exception)
            {
                bSuccess = false;
                OnProcessExceptionNotify(new TaskExceptionEventArgs(exception));
            }
            finally
            {
                OnProcessCompleteNotify(new TaskCompleteEventArgs(bSuccess));
            }

        }
        #endregion

        #region - Private Methods -
        /// <exception cref="InvalidFileException">
        /// <paramref name="file"/>'s extension is unknown and cannot be parsed.-or-
        /// <paramref name="file"/> could not be loaded.
        /// </exception>
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

        #endregion

        #region - Event Handlers -
        public event TaskNotifyHandler ProcesNotify;
        protected void OnProcesNotify(object sender, TaskEventArgs args)
        {
            TaskNotifyHandler handler = ProcesNotify;
            if (handler != null) handler(sender, args);
        }

        public event TaskInfoNotifyHandler ProcessInfoNotify;
        protected void OnProcessInfoNotify(object sender, TaskInfoEventArgs args)
        {
            TaskInfoNotifyHandler handler = ProcessInfoNotify;
            if (handler != null) handler(sender, args);
        }

        public event TaskStartNotifyHandler ProcessStartNotify;

        protected virtual void OnProcessStartNotify()
        {
            TaskStartNotifyHandler handler = ProcessStartNotify;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event TaskCompleteNotifyHandler ProcessCompleteNotify;

        protected virtual void OnProcessCompleteNotify(TaskCompleteEventArgs args)
        {
            TaskCompleteNotifyHandler handler = ProcessCompleteNotify;
            if (handler != null) handler(this, args);
        }

        public event TaskExceptionNotifyHandler ProcessExceptionNotify;

        protected virtual void OnProcessExceptionNotify(TaskExceptionEventArgs args)
        {
            TaskExceptionNotifyHandler handler = ProcessExceptionNotify;
            if (handler != null) handler(this, args);
        }

        #endregion
    }


}