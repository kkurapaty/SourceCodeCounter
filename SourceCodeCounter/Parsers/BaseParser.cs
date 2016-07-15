using System;
using System.Linq;
using SourceCodeCounter.Core;
using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Parsers
{
    public abstract class BaseParser
    {
        #region - Private Declarations -
        private int _totalLines;
        private int _codeLines;
        private int _commentedLines;
        private int _blankLines;
        private int _totalFiles;
        bool _isBlankLine = true;
        #endregion

        #region - Protected Declarations -
        protected bool IsBlankLine
        {
            get { return _isBlankLine; }
            set { _isBlankLine = value; }
        }
        protected bool ContainsComment { get; set; }
        protected bool ContainsCode { get; set; }
        protected IComment Comment { get; set; }
        #endregion

        #region - Abstract Methods -
        protected abstract int ParseString(string line, int index);
        #endregion

        #region - Public Declarations -
        public virtual void Reset()
        {
            _totalLines = 0;
            _codeLines = 0;
            _commentedLines = 0;
            _blankLines = 0;
            _totalFiles = 1;
        }

        public SourceResult GenerateResult()
        {
            return new SourceResult(_totalLines, _codeLines, _commentedLines, _blankLines, _totalFiles);
        }

        public virtual void ParseNextLine(string line)
        {
            if (line == null)
                throw new ArgumentNullException("line");

            IsBlankLine = true;
            ContainsCode = false;
            ContainsComment = false;

            for (int index = 0; index < line.Length; )
                index += ParseString(line, index);

            if (IsBlankLine) _blankLines++;
            if (ContainsComment) _commentedLines++;
            if (ContainsCode) _codeLines++;

            _totalLines++;
        }
        #endregion

        #region - Static Declarations -
        protected static bool ContainsSubstring(string line, int index, string substring)
        {
            if (line == null || substring == null)
                return false;

            if (line.Length < index + substring.Length || index < 0)
                return false;

            return !substring.Where((t, i) => t != line[index + i]).Any();
        }
        #endregion
    }
}
