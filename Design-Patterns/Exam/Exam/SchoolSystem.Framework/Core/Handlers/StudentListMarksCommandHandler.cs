using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Handlers
{
    public class StudentListMarksCommandHandler : Handler
    {
        public StudentListMarksCommandHandler(ICommandsFactory commandsFactory)
            : base(commandsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "StudentListMarks";
        }

        protected override ICommand Handle()
        {
            return this.CommandsFactory.GetStudentListMarksCommand();
        }
    }
}
