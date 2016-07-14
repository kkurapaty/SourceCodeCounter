using System;
using System.IO;
using System.Xml;
using SourceCodeCounter.Interfaces;
using SourceCodeCounter.Properties;

namespace SourceCodeCounter.Core
{
    public class SourceFile : ISourceFile
    {
        #region - Private Declarations -
        ISourceResult _report;
        readonly FileInfo _file;
        readonly string _fileKey;

        private static string GenerateFileKey(FileInfo file)
        {
            if (IgnoreCase)
                return file.FullName.ToLower();
            return file.FullName;
        }

        #endregion

        #region - Internal Declarations -

        internal string FileKey
        {
            get { return _fileKey; }
        }

        public void Serialize(XmlElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            XmlDocument document = element.OwnerDocument;
            if (document == null) return;

            XmlElement dirElement = document.CreateElement("Directory");
            XmlElement nameElement = document.CreateElement("FileName");
            XmlElement resultElement = document.CreateElement("Result");

            dirElement.InnerText = Directory;
            nameElement.InnerText = Name;
            if (_report != null)
                _report.Serialize(resultElement);

            element.AppendChild(dirElement);
            element.AppendChild(nameElement);
            element.AppendChild(resultElement);
        }
        #endregion

        #region - Constructor -
        private SourceFile()
        {
            Report = new SourceResult();
        }
        public SourceFile(string filePath):this()
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");

            try
            {
                _file = new FileInfo(filePath);
                _fileKey = GenerateFileKey(_file);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(Resources.Resource_InvalidFilePath, "filePath", ex);
            }
        }

        public SourceFile(FileInfo fileInfo):this()
        {
            if (fileInfo == null)
                throw new ArgumentNullException("fileInfo");

            _file = fileInfo;
            _fileKey = GenerateFileKey(_file);
        }
        #endregion

        #region - Public Declarations -
        public static bool IgnoreCase
        {
            get { return (Environment.OSVersion.Platform != PlatformID.Unix); }
        }

        public string Name
        {
            get { return _file.Name; }
        }

        public string Directory
        {
            get { return _file.DirectoryName; }
        }

        public string Path
        {
            get { return _file.FullName; }
        }

        public string Extension
        {
            get { return _file.Extension; }
        }

        public long Size { get { return _file.Length; } }

        public ISourceResult Report
        {
            get { return _report; }
            set { _report = value; }
        }
        #endregion

        #region - Public Overrides -
        public override bool Equals(object obj)
        {
            return (obj is SourceFile && ((SourceFile)obj)._fileKey == _fileKey);
        }

        public override int GetHashCode()
        {
            return _fileKey.GetHashCode();
        }

        public override string ToString()
        {
            return _file.FullName;
        }
        #endregion
    }
}