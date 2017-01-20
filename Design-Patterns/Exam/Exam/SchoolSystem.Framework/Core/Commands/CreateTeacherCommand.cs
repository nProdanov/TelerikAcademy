using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Factories;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private int currentTeacherId;
        private IMarksFactory marksFactory;
        private ITeachersFactory teachersFactory;

        public CreateTeacherCommand(ITeachersFactory teachersFactory, IMarksFactory marksFactory)
        {
            if (teachersFactory == null)
            {
                throw new ArgumentNullException("Teachers factory cannot be null");
            }

            if (marksFactory == null)
            {
                throw new ArgumentNullException("Marks factory cannot be null");
            }

            this.teachersFactory = teachersFactory;
            this.marksFactory = marksFactory;
            this.currentTeacherId = 0;
        }

        public string Execute(IList<string> parameters, ITeachersStudentsOperator teachersStudentsOperator)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teachersFactory.CreateTeaccher(firstName, lastName, subject, this.marksFactory);
            teachersStudentsOperator.AddTeacher(this.currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {this.currentTeacherId++} was created.";
        }
    }
}
