using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Handlers
{
    public class RemoveStudentCommandHandler : Handler
    {
        public RemoveStudentCommandHandler(ICommandsFactory commandsFactory)
            : base(commandsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "RemoveStudent";
        }

        protected override ICommand Handle()
        {
            return this.CommandsFactory.GetRemoveStudentCommand();
        }
    }
}
