using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Handlers
{
    public class RemoveTeacherCommandHandler : Handler
    {
        public RemoveTeacherCommandHandler(ICommandsFactory commandsFactory)
            : base(commandsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "RemoveTeacher";
        }

        protected override ICommand Handle()
        {
            return this.CommandsFactory.GetRemoveTeacherCommand();
        }
    }
}
