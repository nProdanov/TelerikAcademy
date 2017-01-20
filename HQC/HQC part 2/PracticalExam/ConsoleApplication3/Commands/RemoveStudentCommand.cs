using System.Collections.Generic;

using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public class RemoveStudentCommand : Command, ICommand
    {
        public RemoveStudentCommand()
            : base()
        {
        }

        public override string Execute(IList<string> commandParams)
        {
            var studentToRemoveId = int.Parse(commandParams[0]);
            this.Engine.RemoveStudentById(studentToRemoveId);

            return $"Student with ID {studentToRemoveId} was sucessfully removed.";
        }
    }
}
