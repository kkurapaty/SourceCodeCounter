using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SourceCodeCounter.Common;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Core
{
    /// <summary>
    /// Represents a named group that contains related source files.
    /// </summary>
    public class Project : IProject
    {
        #region - Constructor -
        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class with 
        /// the specified name.
        /// </summary>
        /// <param name="name">The name of the project. It cannot be null or 
        /// empty string.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="name"/> is null or empty string.
        /// </exception>
        public Project(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) name = "Instance Project";
            Name = name;
            Report = new SourceResult();
        }
        #endregion

        #region - Private Declarations -
        //readonly Dictionary<string, SourceFile> files = new Dictionary<string, SourceFile>(10);
        private readonly IList<SourceFile> _files = new List<SourceFile>();

        #endregion
        
        #region - Public Declarations -
        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        public string Name { get ; private set; }

        /// <summary>
        /// Gets the collection of the files contained by the project. 
        /// </summary>
        public IEnumerable<SourceFile> Files
        {
            get { return _files; }
        }

        /// <summary>
        /// Gets the total number of source files.
        /// </summary>
        public int FileCount
        {
            get { return _files.Count; }
        }

        public int TotalLines
        {
            get { return _files.Where(x=> x.Report!= null).Sum(x => x.Report.TotalLines); }
        }

        public int Comments
        {
            get { return _files.Where(x => x.Report != null).Sum(x => x.Report.CommentLines); }
        }

        public int CodeLines
        {
            get { return _files.Where(x => x.Report != null).Sum(x => x.Report.CodeLines); }
        }

        public int BlankLines
        {
            get { return _files.Where(x => x.Report != null).Sum(x => x.Report.BlankLines); }
        }

        /// <summary>
        /// Gets or sets the results of a successful counting.
        /// </summary>
        /// <value>The <see cref="SourceResult"/> object of a 
        /// successful counting or null.</value>
        public SourceResult Report { get; set; }

        /// <summary>
        /// Adds a source file to the project if it the project does not 
        /// yet contain a similar file.
        /// </summary>
        /// <param name="file">The file to be added. If the 
        /// <paramref name="file"/> is null, nothing happens.</param>
        public void AddFile(SourceFile file)
        {
            if (file == null) return;
            if (!HelperClass.IsValidExtension(file.Extension)) return;
            if (!Exists(file)) _files.Add(file);
        }

        /// <summary>
        /// Determines whether the project has a similar file.
        /// </summary>
        /// <param name="file">The file to locate in the project.</param>
        /// <returns>true if the file is found in the project; otherwise, 
        /// false.</returns>
        public bool Contains(SourceFile file)
        {
            if (file == null)
                return false;
            return _files.Contains(file);
        }

        /// <summary>
        /// Returns a similar file containing by the project.
        /// </summary>
        /// <param name="file">The file to locate in the project.</param>
        /// <returns>A <see cref="SourceFile"/> object of the project that is 
        /// similar to the given <paramref name="file"/> or null if the project 
        /// does not contain such file.</returns>
        public SourceFile Find(SourceFile file)
        {
            return file == null ? null : _files.FirstOrDefault(sourceFile => (sourceFile.Name.Equals(file.Name) && sourceFile.Size == file.Size));
        }
        public bool Exists(SourceFile file)
        {
            if (file == null) return false;
            return (null != Find(file));
        }

        /// <summary>
        /// Removes the file from the project.
        /// </summary>
        /// <param name="file">The file to remove from the project.</param>
        /// <returns>true if the file is successfully removed; otherwise, false.
        /// </returns>
        public bool Remove(SourceFile file)
        {
            if (file == null) return false;
            return _files.Remove(file);
        }

        /// <summary>
        /// Excludes every file matching the pattern.
        /// </summary>
        /// <param name="pattern">A <see cref="Regex"/> pattern for the file's 
        /// name.</param>
        /// <returns>The count of the removed files.</returns>
        public int ExcludeFiles(Regex pattern)
        {
            if (pattern == null)
                return 0;

            var blacklist = new List<SourceFile>(_files);

            // Remove files from blacklist that are not matching the pattern
            blacklist.RemoveAll(file => !pattern.IsMatch(file.Name));

            // Remove files from the project specified by the blacklist
            foreach (SourceFile t in blacklist)
                _files.Remove(t);

            return blacklist.Count;
        }
        #endregion

        #region - Internal Methods -

        #endregion

        #region - Override Methods -
        /// <summary>
        /// Returns the name of the project.
        /// </summary>
        /// <returns>The name of the project.</returns>
        public override string ToString()
        {
            return String.Format("{0} - ({1})", Name, FileCount);
        }
        
        public override bool Equals(object obj)
        {
            return (obj is Project && ((Project)obj).Name == Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        #endregion
    }
}