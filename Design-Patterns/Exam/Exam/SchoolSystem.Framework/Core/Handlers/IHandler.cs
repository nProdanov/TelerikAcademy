using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Handlers
{
    public interface IHandler
    {
        ICommand HandleCommand(string commandName);

        void SetSuccessor(IHandler successor);
    }
}
