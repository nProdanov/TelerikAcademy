using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Factories;
using SchoolSystem.Framework.Core.Commands;

namespace SchoolSystem.Framework.Core.Handlers
{
    public class CreateTeacherCommandHandler : Handler
    {
        private IMarksFactory marksFactory;
        private ITeachersFactory teachersFactory;

        public CreateTeacherCommandHandler(ICommandsFactory commandsFactory, ITeachersFactory teachersFactory, IMarksFactory marksFactory)
            : base(commandsFactory)
        {
            this.teachersFactory = teachersFactory;
            this.marksFactory = marksFactory;

        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "CreateTeacher";
        }

        protected override ICommand Handle()
        {
            return this.CommandsFactory.GetCreateTeacherCommand(this.teachersFactory, this.marksFactory);
        }
    }
}
