using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters, ITeachersStudentsOperator teachersStudentsOperator)
        {
            var teacherId = int.Parse(parameters[0]);

            teachersStudentsOperator.RemoveTeacher(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
