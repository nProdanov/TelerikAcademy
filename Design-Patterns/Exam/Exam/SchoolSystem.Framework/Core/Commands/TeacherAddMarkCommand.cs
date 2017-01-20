using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters, ITeachersStudentsOperator teachersStudentsOperator)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("Command Parameteres cannot be null");
            }

            if (teachersStudentsOperator == null)
            {
                throw new ArgumentNullException("Teachers - Students Operator Parameteres cannot be null");
            }

            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = teachersStudentsOperator.GetStudentById(studentId);
            var teacher = teachersStudentsOperator.GetTeacherById(teacherId);

            teacher.AddMark(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
