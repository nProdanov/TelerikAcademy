namespace SchoolSsystem
{
    using System.Collections.Generic;

    public interface ICommentable
    {
        List<string> Comments { get; }

        void AddComment(string comment);
    }
}
