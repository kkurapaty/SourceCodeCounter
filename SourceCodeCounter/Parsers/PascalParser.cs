using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Parsers
{
    internal class PascalParser : BaseParser
    {
        #region - Constructor -
        public PascalParser()
        {
            Comment = new Comment("//", new CommentBlock("{", "}"), new CommentBlock("(*", "*)"));
        }
        public PascalParser(IComment comment)
        {
            Comment = comment;
        }
        #endregion

        #region - Static Instance -
        public static readonly PascalParser Instance = new PascalParser();
        #endregion

        #region - Private Declrations -
        private bool _inMultiLineComment;
        private bool _inOldMultiLineComment;
        private bool _inString;
        #endregion

        #region - Protected Declarations -
        protected bool InString
        {
            get { return _inString; }
        }

        protected bool InMultiLineComment
        {
            get { return _inMultiLineComment; }
        }

        protected bool InOldMultiLineComment
        {
            get { return _inOldMultiLineComment; }
        }

        protected override int ParseString(string line, int index)
        {
            if (line == null || index < 0 || index > line.Length)
                return 0;

            if (char.IsWhiteSpace(line[index]))
                return 1;

            IsBlankLine = false;

            if (_inMultiLineComment)
            {
                if (line[index] == Comment.MultiLine.End[0])
                    _inMultiLineComment = false;
                else
                    ContainsComment = true;
                return 1;
            }
            if (_inOldMultiLineComment)
            {
                if (ContainsSubstring(line, index, Comment.Extended.End))
                {
                    _inOldMultiLineComment = false;
                    return 2;
                }
                ContainsComment = true;
                return 1;
            }
            if (_inString)
            {
                if (line[index] == '\'')
                    _inString = false;
                return 1;
            }
            if (line[index] ==  Comment.MultiLine.Begin[0]) // Check for pre-processor directives here "{$"
            {
                _inMultiLineComment = true;
                return 1;
            }
            if (ContainsSubstring(line, index, Comment.Extended.Begin))
            {
                _inOldMultiLineComment = true;
                return 2;
            }
            if (line[index] == '\'')
            {
                _inString = true;
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
            _inOldMultiLineComment = false;
            base.Reset();
        }

        public override void ParseNextLine(string line)
        {
            _inString = false;
            base.ParseNextLine(line);
        }
        #endregion
    }
}