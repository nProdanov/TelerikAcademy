using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core
{
    public interface ITeachersStudentsOperator
    {
        void AddStudent(int studentId, IStudent student);

        void AddTeacher(int teacherId, ITeacher teacher);

        IStudent GetStudentById(int studentId);

        ITeacher GetTeacherById(int teacherId);

        void RemoveStudent(int studentId);

        void RemoveTeacher(int teacherId);
    }
}