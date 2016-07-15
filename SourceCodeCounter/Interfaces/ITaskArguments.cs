using System.Text;
using SourceCodeCounter.Process;

namespace SourceCodeCounter.Interfaces
{
    public interface ITaskArguments
    {
        ISourceHandler SourceHandler { get; }
        StringBuilder Output { get; }

        bool ShowFiles { get; }
        bool ShowProjects { get; }
        bool ShowSummary { get; }
        bool ShowPercentage { get; }

        void AddProject(string projectTitle, string projectPath, bool includeSubDir);
        void ClearProjects();
        void AddExcludeOption(string param);
        event TaskExceptionNotifyHandler ProcessExceptionNotify;
    }
}