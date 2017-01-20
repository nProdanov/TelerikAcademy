using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Factories;

namespace SchoolSystem.Framework.Core.Handlers
{
    public class CreateStudentCommandHandler : Handler
    {
        private IStudentsFactory studentsFactory;

        public CreateStudentCommandHandler(ICommandsFactory commandsFactory, IStudentsFactory studentsFactory)
            : base(commandsFactory)
        {
            this.studentsFactory = studentsFactory;
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "CreateStudent";
        }

        protected override ICommand Handle()
        {
            return this.CommandsFactory.GetCreateStudentCommand(this.studentsFactory);
        }
    }
}
