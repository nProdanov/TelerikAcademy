using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
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

            var studentId = int.Parse(parameters[0]);
            teachersStudentsOperator.RemoveStudent(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
