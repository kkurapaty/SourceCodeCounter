using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Parsers
{
    public class Comment: IComment
    {
        #region - Constructors -
        public Comment (string singleLine)
        {
            SingleLine = singleLine;
        }

        public Comment(string singleLine, ICommentBlock multiLine):this(singleLine)
        {
            MultiLine = multiLine;
        }

        public Comment(string singleLine, ICommentBlock multiLine, ICommentBlock extended)
            : this(singleLine, multiLine)
        {
            Extended = extended;
        }
        #endregion

        #region - IComment Properties -
        public string SingleLine { get; protected set; }
        public ICommentBlock MultiLine { get; protected set; }
        public ICommentBlock Extended { get; protected set; }
        #endregion
    }
}