using System.Collections.Generic;
using System.Text.RegularExpressions;
using SourceCodeCounter.Core;

namespace SourceCodeCounter.Interfaces
{
    public interface IProject
    {
        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the collection of the files contained by the project. 
        /// </summary>
        IEnumerable<SourceFile> Files { get; }

        /// <summary>
        /// Gets the total number of source files.
        /// </summary>
        int FileCount { get; }

        int TotalLines { get; }
        int Comments { get; }
        int CodeLines { get; }
        int BlankLines { get; }
        /// <summary>
        /// Gets or sets the results of a successful counting.
        /// </summary>
        /// <value>The <see cref="SourceResult"/> object of a 
        /// successful counting or null.</value>
        SourceResult Report { get; set; }

        /// <summary>
        /// Adds a source file to the project if it the project does not 
        /// yet contain a similar file.
        /// </summary>
        /// <param name="file">The file to be added. If the 
        /// <paramref name="file"/> is null, nothing happens.</param>
        void AddFile(SourceFile file);

        /// <summary>
        /// Determines whether the project has a similar file.
        /// </summary>
        /// <param name="file">The file to locate in the project.</param>
        /// <returns>true if the file is found in the project; otherwise, 
        /// false.</returns>
        bool Contains(SourceFile file);

        /// <summary>
        /// Returns a similar file containing by the project.
        /// </summary>
        /// <param name="file">The file to locate in the project.</param>
        /// <returns>A <see cref="SourceFile"/> object of the project that is 
        /// similar to the given <paramref name="file"/> or null if the project 
        /// does not contain such file.</returns>
        SourceFile Find(SourceFile file);

        /// <summary>
        /// Removes the file from the project.
        /// </summary>
        /// <param name="file">The file to remove from the project.</param>
        /// <returns>true if the file is successfully removed; otherwise, false.
        /// </returns>
        bool Remove(SourceFile file);

        /// <summary>
        /// Excludes every file matching the pattern.
        /// </summary>
        /// <param name="pattern">A <see cref="Regex"/> pattern for the file's 
        /// name.</param>
        /// <returns>The count of the removed files.</returns>
        int ExcludeFiles(Regex pattern);

        /// <summary>
        /// Returns the name of the project.
        /// </summary>
        /// <returns>The name of the project.</returns>
        string ToString();
    }
}