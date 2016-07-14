using System;
using System.Globalization;
using System.Xml;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Core
{

    /// <summary>
    /// Contains counting result informations.
    /// </summary>
    public class SourceResult : ISourceResult
    {
        #region - Constructor -

        public SourceResult() : this(0, 0, 0, 0, 0)
        {
          // Just an empty constructor   
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceResult"/> class
        /// with the specified line counts.
        /// </summary>
        /// <param name="total">The total number of lines.</param>
        /// <param name="code">The total number of code lines.</param>
        /// <param name="comments">The total number of comment lines.</param>
        /// <param name="blanks">The total number of blank lines.</param>
        /// <param name="totalFiles">The total number of files.</param>
        public SourceResult(int total, int code, int comments, int blanks, int totalFiles)
        {
            if (_totalLines < 0)
                throw new ArgumentOutOfRangeException("total");

            if (_codeLines < 0 || _codeLines > _totalLines)
                throw new ArgumentOutOfRangeException("code");

            if (_commentLines < 0 || _commentLines > _totalLines)
                throw new ArgumentOutOfRangeException("comments");

            if (_blankLines < 0 || _blankLines > _totalLines)
                throw new ArgumentOutOfRangeException("blanks");

            _totalLines = total;
            _codeLines = code;
            _commentLines = comments;
            _blankLines = blanks;
            _fileCount = totalFiles;
            _mixedLines = (total - (_codeLines + _commentLines + _blankLines));
        }

        #endregion

        #region - Private Declarations -

        private readonly int _totalLines;
        private readonly int _codeLines;
        private readonly int _commentLines;
        private readonly int _blankLines;
        private readonly int _fileCount;
        private readonly int _mixedLines;

        #endregion

        #region - Internal Declarations -

        /// <summary>
        /// Serializes counting informations.
        /// </summary>
        /// <param name="element">An <see cref="XmlElement"/> node 
        /// used to write counting informations.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="element"/> is null.
        /// </exception>
        public void Serialize(XmlElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            XmlDocument document = element.OwnerDocument;
            if (document == null) return;
            XmlElement totalElement = document.CreateElement("Total");
            XmlElement codeElement = document.CreateElement("Code");
            XmlElement commentElement = document.CreateElement("Comment");
            XmlElement blankElement = document.CreateElement("Blank");
            //XmlElement filesElement = document.CreateElement("Files");
            totalElement.InnerText = _totalLines.ToString(CultureInfo.InvariantCulture);
            codeElement.InnerText = _codeLines.ToString(CultureInfo.InvariantCulture);
            commentElement.InnerText = _commentLines.ToString(CultureInfo.InvariantCulture);
            blankElement.InnerText = _blankLines.ToString(CultureInfo.InvariantCulture);

            element.AppendChild(totalElement);
            element.AppendChild(codeElement);
            element.AppendChild(commentElement);
            element.AppendChild(blankElement);
        }

        #endregion

        #region - Public Declarations -

        /// <summary>
        /// Gets the total numbers of files.
        /// </summary>
        public int TotalFiles
        {
            get { return _fileCount; }
        }

        /// <summary>Gets the total number of lines.</summary>
        public int TotalLines
        {
            get { return (_totalLines); }
        }

        /// <summary>Gets the total number of code lines.</summary>
        public int CodeLines
        {
            get { return _codeLines; }
        }

        /// <summary>Gets the total number of comment lines.</summary>
        public int CommentLines
        {
            get { return _commentLines; }
        }

        /// <summary>Gets the total number of blank lines.</summary>
        public int BlankLines
        {
            get { return _blankLines; }
        }

        public int MixedLines { get { return _mixedLines; } }

        /// <summary>Gets the percentage of code lines.</summary>
        public float PercentageOfCodeLines
        {
            get
            {
                if (_totalLines != 0)
                    return ((float) _codeLines / _totalLines * 100);
                return 0;
            }
        }

        /// <summary>Gets the percentage of comment lines.</summary>
        public float PercentageOfCommentLines
        {
            get
            {
                if (_totalLines != 0)
                    return ((float) _commentLines / _totalLines * 100);
                return 0;
            }
        }

        /// <summary>Gets the percentage of blank lines.</summary>
        public float PercentageOfBlankLines
        {
            get
            {
                if (_totalLines != 0)
                    return ((float) _blankLines / _totalLines * 100);
                return 0;
            }
        }

        public float PercentageOfMixedLines
        {
            get
            {
                if (_totalLines != 0)
                    return ((float)_mixedLines / _totalLines * 100);
                return 0;
            }
        }
        /// <summary>
        /// Returns a string that represents the current <see cref="SourceResult"/>.
        /// </summary>
        /// <returns>A string that represents the current <see cref="SourceResult"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Files: {0}, Code: {1}, Comment: {2}, Blank: {3}, Unknown: {4}, Total: {5} ", 
                _fileCount.ToString("#,###"), _codeLines.ToString("#,###"), _commentLines.ToString("#,###"),
                _blankLines.ToString("#,###"), _mixedLines.ToString("#,###"), _totalLines.ToString("#,###"));
        }

        #endregion
    }
}
