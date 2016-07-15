using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SourceCodeCounter.Core;

namespace SourceCodeCounter.Interfaces
{
    public interface ISourceResult
    {
        /// <summary>
        /// Serializes counting informations.
        /// </summary>
        /// <param name="element">An <see cref="XmlElement"/> node 
        /// used to write counting informations.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="element"/> is null.
        /// </exception>
        void Serialize(XmlElement element);

        /// <summary>
        /// Gets the total numbers of files.
        /// </summary>
        int TotalFiles { get; }

        /// <summary>Gets the total number of lines.</summary>
        int TotalLines { get; }

        /// <summary>Gets the total number of code lines.</summary>
        int CodeLines { get; }

        /// <summary>Gets the total number of comment lines.</summary>
        int CommentLines { get; }

        /// <summary>Gets the total number of blank lines.</summary>
        int BlankLines { get; }

        int MixedLines { get; }

        /// <summary>Gets the percentage of code lines.</summary>
        float PercentageOfCodeLines { get; }

        /// <summary>Gets the percentage of comment lines.</summary>
        float PercentageOfCommentLines { get; }

        /// <summary>Gets the percentage of blank lines.</summary>
        float PercentageOfBlankLines { get; }

        float PercentageOfMixedLines { get; }

        /// <summary>
        /// Returns a string that represents the current <see cref="SourceResult"/>.
        /// </summary>
        /// <returns>A string that represents the current <see cref="SourceResult"/>.
        /// </returns>
        string ToString();
    }
}
