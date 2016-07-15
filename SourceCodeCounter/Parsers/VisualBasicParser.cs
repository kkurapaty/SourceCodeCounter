namespace SourceCodeCounter.Parsers
{
    internal class VisualBasicParser : BaseParser
    {
        #region - Constructor -
        public static readonly VisualBasicParser Instance = new VisualBasicParser();
        #endregion

        #region - Private Declarations -
        private bool _inSingleLineComment;
        private bool _inString;
        #endregion

        #region - Protected Declarations -
        protected bool InString
        {
            get { return _inString; }
        }
        protected bool InSingleLineComment
        {
            get { return _inSingleLineComment; }
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
            if (_inString)
            {
                if (line[index] == '"')
                    _inString = false;
                return 1;
            }
            if (line[index] == '\'')
            {
                _inSingleLineComment = true;
                return 1;
            }
            if (line[index] == '"')
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
        public override void ParseNextLine(string line)
        {
            _inString = false;
            _inSingleLineComment = false;
            base.ParseNextLine(line);
        }
        #endregion
    }
}