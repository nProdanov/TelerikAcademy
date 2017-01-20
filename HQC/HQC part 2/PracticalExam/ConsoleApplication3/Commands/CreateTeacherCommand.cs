using System.Collections.Generic;

using SchoolSystem.Contracts;
using SchoolSystem.Models.SchoolActors;
using SchoolSystem.Types;

namespace SchoolSystem.Commands
{
    public class CreateTeacherCommand : Command, ICommand
    {
        private int id;

        public CreateTeacherCommand()
            : base()
        {
            this.id = 0;
        }

        public override string Execute(IList<string> commandParams)
        {
            var firstTeacherName = commandParams[0];
            var lastTeacherName = commandParams[1];
            var teacherSubjectId = int.Parse(commandParams[2]);
            this.Engine.AddTeacher(this.id, new Teacher(firstTeacherName, lastTeacherName, (SubjectType)teacherSubjectId));

            var result = $"A new teacher with name {firstTeacherName} {lastTeacherName}, subject {(SubjectType)teacherSubjectId} and ID {this.id} was created.";
            this.id++;

            return result;
        }
    }
}
