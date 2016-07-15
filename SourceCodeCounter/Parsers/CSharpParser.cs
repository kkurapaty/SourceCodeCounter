namespace SourceCodeCounter.Parsers
{
    internal class CSharpParser : CParser
    {
        #region - Constructor -

        public new static readonly CSharpParser Instance = new CSharpParser();

        #endregion

        #region - Public Declarations -

        private bool _inVerbatimString;

        #endregion

        #region - Protected Declarations -

        protected bool InVerbatimString
        {
            get { return _inVerbatimString; }
        }

        protected override int ParseString(string line, int index)
        {
            if (InString || InChar || InSingleLineComment || InMultiLineComment)
                return base.ParseString(line, index);

            if (line == null || index < 0 || index > line.Length)
                return 0;

            if (_inVerbatimString)
            {
                if (char.IsWhiteSpace(line[index]))
                {
                    return 1;
                }
                IsBlankLine = false;
                ContainsCode = true;

                if (ContainsSubstring(line, index, "\"\""))
                {
                    return 2;
                }
                if (line[index] == '"')
                {
                    _inVerbatimString = false;
                    return 1;
                }
                return 1;
            }
            if (ContainsSubstring(line, index, "@\""))
            {
                _inVerbatimString = true;
                ContainsCode = true;
                IsBlankLine = false;
                return 2;
            }
            return base.ParseString(line, index);
        }

        #endregion

        #region - Public Declarations -

        public override void Reset()
        {
            _inVerbatimString = false;
            base.Reset();
        }

        #endregion
    }
}