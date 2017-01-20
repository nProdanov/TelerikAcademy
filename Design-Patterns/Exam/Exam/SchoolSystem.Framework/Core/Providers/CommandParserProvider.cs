using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Handlers;

namespace SchoolSystem.Framework.Core.Providers
{
    public class CommandParserProvider : IParser
    {
        private IHandler commandsHandler;

        public CommandParserProvider(IHandler commandsHandler)
        {
            this.commandsHandler = commandsHandler;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var command = this.commandsHandler.HandleCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }
    }
}
