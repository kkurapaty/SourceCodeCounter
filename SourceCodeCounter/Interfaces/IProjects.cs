using System.Collections.Generic;
using SourceCodeCounter.Core;

namespace SourceCodeCounter.Interfaces
{
    public interface IProjects
    {
        IList<Project> Items { get; }
        int Count { get; }
        int FilesCount { get; }
        int TotalLines { get; }
        int Comments { get; }
        int CodeLines { get; }
        int BlankLines { get; }
        void AddFile(SourceFile file, Project targetProject);
        void Sort();
        Project FindProject(string projectName);
        Project AddProject(string projectName);
        void RemoveProject(string projectName);
    }
}