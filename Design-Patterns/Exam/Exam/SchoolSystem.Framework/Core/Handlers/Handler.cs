using System;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Commands;

namespace SchoolSystem.Framework.Core.Handlers
{
    public abstract class Handler : IHandler
    {
        private ICommandsFactory commandsFactory;

        public Handler(ICommandsFactory commandsFactory)
        {
            this.commandsFactory = commandsFactory;
        }

        protected ICommandsFactory CommandsFactory
        {
            get
            {
                return this.commandsFactory;
            }
        }

        private IHandler Successor { get; set; }

        public ICommand HandleCommand(string commandName)
        {
            if (this.CanHandle(commandName))
            {
                return this.Handle();
            }

            if (this.Successor != null)
            {
                return this.Successor.HandleCommand(commandName);
            }

            throw new ArgumentException("The passed command is not found!");
        }

        public void SetSuccessor(IHandler successor)
        {
            this.Successor = successor;
        }

        protected abstract bool CanHandle(string commandName);

        protected abstract ICommand Handle();
    }
}
