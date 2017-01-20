using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Factories;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private int currentStudentId;

        private IStudentsFactory studentsFactory;

        public CreateStudentCommand(IStudentsFactory studentsFactory)
        {
            if (studentsFactory == null)
            {
                throw new ArgumentNullException("Students factory cannot be null");
            }

            this.studentsFactory = studentsFactory;
            this.currentStudentId = 0;
        }

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

            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.studentsFactory.CreateStudent(firstName, lastName, grade);
            teachersStudentsOperator.AddStudent(this.currentStudentId, student);
            
            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {this.currentStudentId++} was created.";
        }
    }
}
