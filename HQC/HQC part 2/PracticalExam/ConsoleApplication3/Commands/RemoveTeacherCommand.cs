using System.Collections.Generic;

using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public class RemoveTeacherCommand : Command, ICommand
    {
        public RemoveTeacherCommand()
            : base()
        {
        }

        public override string Execute(IList<string> commandParams)
        {
            var teacherToRemoveId = int.Parse(commandParams[0]);
            this.Engine.RemoveStudentById(teacherToRemoveId);

            return $"Teacher with ID {teacherToRemoveId} was sucessfully removed.";
        }
    }
}
