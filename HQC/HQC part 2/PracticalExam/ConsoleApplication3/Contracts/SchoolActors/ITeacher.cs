using SchoolSystem.Types;

namespace SchoolSystem.Contracts.SchoolActors
{
    /// <summary>
    /// Teacher is a School actor who teach and tests students, then add them marks
    /// </summary>
    public interface ITeacher : ISchoolActor
    {
        /// <summary>
        /// Scope of Teach knowledge
        /// </summary>
        SubjectType Subject { get; set; }

        /// <summary>
        /// Teacher add mark on student
        /// </summary>
        /// <param name="student">The school actor who get the mark</param>
        /// <param name="markToAdd">Mark of test result</param>
        void AddMark(IStudent student, IMark markToAdd);
    }
}