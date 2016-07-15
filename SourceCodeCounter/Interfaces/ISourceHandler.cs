using SourceCodeCounter.Core;

namespace SourceCodeCounter.Interfaces
{
    public interface ISourceHandler
    {
        int FileCount { get; }
        IProjects Projects { get; }
        SourceResult Report { get; set; }
        string GetAsXml();
    }
}
