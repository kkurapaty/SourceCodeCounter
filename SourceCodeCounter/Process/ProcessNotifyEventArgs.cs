using System;
using System.ComponentModel;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Process
{
    public class TaskEventArgs : EventArgs
    {
        public string FileName { get; private set; }

        public TaskEventArgs(string fileName)
        {
            FileName = fileName;
        }

        public override string ToString()
        {
            return string.Format("Processing {0} ...", FileName);
        }
    }

    public class TaskInfoEventArgs : EventArgs
    {
        public string ProjectName { get; private set; }
        public string FileName { get; private set; }
        public ISourceResult Result { get; private set; }

        public TaskInfoEventArgs(string projectName, string fileName, ISourceResult sourceResult)
        {
            ProjectName = projectName;
            FileName = fileName;
            Result = sourceResult;
        }

        public override string ToString()
        {
            return string.Format("Processed: {0} {1} Data:{2}", ProjectName, FileName, Result);
        }
    }

    public class TaskCompleteEventArgs : EventArgs
    {
        public bool Success { get; private set; }
        public TaskCompleteEventArgs(bool success)
        {
            Success = success;
        }
    }

    public class TaskExceptionEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }
        public TaskExceptionEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
    
    public class TaskProgressChangedEventArgs : ProgressChangedEventArgs
    {
        public String Result { get; private set; }
        public ProgressStatus Status { get; private set; }
        public TaskProgressChangedEventArgs(ProgressStatus status, String statusText, int progressPercent, object userState)
            : base(progressPercent, userState)
        {
            Result = statusText;
            Status = status;
        }
    }
}