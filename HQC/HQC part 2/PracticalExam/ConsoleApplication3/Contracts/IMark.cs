using SchoolSystem.Types;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Result of students test
    /// </summary>
    public interface IMark
    {
        /// <summary>
        /// Subject off what is mark
        /// </summary>
        SubjectType Subject { get; }

        /// <summary>
        /// The value of the mark
        /// </summary>
        float Value { get; }
    }
}