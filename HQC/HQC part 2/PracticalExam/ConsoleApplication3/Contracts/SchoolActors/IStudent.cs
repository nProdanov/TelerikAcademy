namespace SchoolSystem.Contracts.SchoolActors
{
    /// <summary>
    /// School actor who study in school system
    /// </summary>
    public interface IStudent : ISchoolActor
    {
        /// <summary>
        /// Grade of Student in system (from 1st to 12th)
        /// </summary>
        int Grade { get; set; }

        /// <summary>
        /// When teacher test the Student, he get a mark from a the test (from 2 - 6)
        /// </summary>
        /// <param name="mark">Mark of test result</param>
        void GetMark(IMark mark);

        /// <summary>
        /// Student list all his marks
        /// </summary>
        /// <returns>Text where are provided all student's marks</returns>
        string ListMarks();
    }
}