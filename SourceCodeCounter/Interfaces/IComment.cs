namespace SourceCodeCounter.Interfaces
{
    public interface IComment
    {
        string SingleLine { get; }
        ICommentBlock MultiLine { get; }
        ICommentBlock Extended { get; }
    }
}
