using System.Xml;

namespace SourceCodeCounter.Interfaces
{
    public interface ISourceFile
    {
        
        string Name { get; }
        string Directory { get; }
        string Path { get; }
        string Extension { get; }
        long Size { get; }
        void Serialize(XmlElement element);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
        ISourceResult Report { get; set; }
    }
}