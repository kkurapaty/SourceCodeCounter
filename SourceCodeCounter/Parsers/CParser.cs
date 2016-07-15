using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Parsers
{
    internal class CParser : BaseParser
    {
        #region - Constructor -
        public CParser()
        {
            Comment = new Comment("//", new CommentBlock("/*", "*/"));
        }
        public CParser(IComment comment)
        {
            Comment = comment;
        }
        #endregion

        #region - Static Instance -
        public static readonly CParser Instance = new CParser();
        #endregion

        #region - Private Declarations -
        private bool _inChar;
        private bool _inMultiLineComment;
        private bool _inSingleLineComment;
        private bool _inString;
        #endregion

        #region - Protected Declarations -
        protected bool InString
        {
            get { return _inString; }
        }

        protected bool InChar
        {
            get { return _inChar; }
        }

        protected bool InSingleLineComment
        {
            get { return _inSingleLineComment; }
        }

        protected bool InMultiLineComment
        {
            get { return _inMultiLineComment; }
        }

        protected override int ParseString(string line, int index)
        {
            if (line == null || index < 0 || index > line.Length)
                return 0;

            if (char.IsWhiteSpace(line[index]))
                return 1;
            
            IsBlankLine = false;

            if (_inSingleLineComment)
            {
                ContainsComment = true;
                return line.Length - index;
            }
            if (_inMultiLineComment)
            {
                if (ContainsSubstring(line, index, Comment.MultiLine.End))
                {
                    _inMultiLineComment = false;
                    return 2;
                }
                ContainsComment = true;
                return 1;
            }
            if (_inString)
            {
                if (ContainsSubstring(line, index, @"\\") || ContainsSubstring(line, index, "\\\"")) return 2;
                
                if (line[index] == '"')
                {
                    _inString = false;
                    return 1;
                }
                return 1;
                
            }
            if (_inChar)
            {
                if (ContainsSubstring(line, index, @"\\") ||ContainsSubstring(line, index, @"\'"))  return 2;
                
                if (line[index] == '\'')
                {
                    _inChar = false;
                    return 1;
                }
                return 1;
            }
            if (ContainsSubstring(line, index, Comment.MultiLine.Begin))
            {
                _inMultiLineComment = true;
                return 2;
            }
            if (ContainsSubstring(line, index, Comment.SingleLine))
            {
                _inSingleLineComment = true;
                return 2;
            }
            if (line[index] == '"')
            {
                _inString = true;
                ContainsCode = true;
                return 1;
            }
            if (line[index] == '\'')
            {
                _inChar = true;
                ContainsCode = true;
                return 1;
            }
            ContainsCode = true;
            return 1;
        }
        #endregion

        #region - Public Declarations -
        public override void Reset()
        {
            _inMultiLineComment = false;
            base.Reset();
        }

        public override void ParseNextLine(string line)
        {
            _inString = false;
            _inChar = false;
            _inSingleLineComment = false;
            base.ParseNextLine(line);
        }
        #endregion
    }
}