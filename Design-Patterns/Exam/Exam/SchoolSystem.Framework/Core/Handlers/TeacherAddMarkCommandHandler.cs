using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Handlers
{
    public class TeacherAddMarkCommandHandler : Handler
    {
        public TeacherAddMarkCommandHandler(ICommandsFactory commandsFactory)
            : base(commandsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "TeacherAddMark";
        }

        protected override ICommand Handle()
        {
            return this.CommandsFactory.GetTeacherAddMarkCommand();
        }
    }
}
