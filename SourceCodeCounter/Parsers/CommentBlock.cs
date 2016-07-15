using SourceCodeCounter.Interfaces;

namespace SourceCodeCounter.Parsers
{
    public class CommentBlock : ICommentBlock
    {
        #region - Constructor -
        public CommentBlock(string begin, string end)
        {
            Begin = begin;
            End = end;
        }
        #endregion

        #region - ICommentBlock Properties -
        public string Begin { get; protected set; }
        public string End { get; protected set; }
        #endregion

    }
}