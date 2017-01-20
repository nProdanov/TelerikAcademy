using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters, ITeachersStudentsOperator teachersStudentsOperator)
        {
            var studentId = int.Parse(parameters[0]);
            var student = teachersStudentsOperator.GetStudentById(studentId);
            return student.ListMarks();
        }
    }
}
