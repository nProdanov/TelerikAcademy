using System.Collections.Generic;

using SchoolSystem.Contracts;
using SchoolSystem.Models.SchoolActors;
using SchoolSystem.Types;

namespace SchoolSystem.Commands
{
    public class CreateStudentCommand : Command, ICommand
    {
        private int id;

        public CreateStudentCommand()
            : base()
        {
            this.id = 0;
        }

        public override string Execute(IList<string> commandParams)
        {
            var firstStudentName = commandParams[0];
            var lastStudentName = commandParams[1];
            var studentGrade = int.Parse(commandParams[2]);
            this.Engine.AddStudent(this.id, new Student(firstStudentName, lastStudentName, studentGrade));

            var result = $"A new student with name {firstStudentName} {lastStudentName}, grade {(GradeType)studentGrade} and ID {this.id} was created.";
            this.id++;

            return result;
        }
    }
}
