using SchoolSystem.Contracts.SchoolActors;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Engine executes command of user
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Start reading and executing commands
        /// </summary>
        void Start();

        /// <summary>
        /// Return teacher by passed ID
        /// </summary>
        /// <param name="teacherId">id of the teacher</param>
        /// <returns>Teacher</returns>
        ITeacher GetTeacherById(int teacherId);

        /// <summary>
        /// Add Teacher to the lists of teachers
        /// </summary>
        /// <param name="teacherId">Teacher id</param>
        /// <param name="teacher">Teacher</param>
        void AddTeacher(int teacherId, ITeacher teacher);

        /// <summary>
        /// Remove teacher by passed ID
        /// </summary>
        /// <param name="teacherId">teacher id</param>
        void RemoveTeacherById(int teacherId);

        /// <summary>
        /// Return student by passed ID
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>Student</returns>
        IStudent GetStudentById(int studentId);

        /// <summary>
        /// Add Student to the list of students
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <param name="student">Student</param>
        void AddStudent(int studentId, IStudent student);

        /// <summary>
        /// Remove student by passed ID
        /// </summary>
        /// <param name="studentId">student id</param>
        void RemoveStudentById(int studentId);
    }
}