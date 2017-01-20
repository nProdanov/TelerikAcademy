using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Command which is get from user and engine understand and executes
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Make things that command parameters say
        /// </summary>
        /// <param name="parameters">Options which user sets after command name</param>
        /// <returns>Message with result after command execution</returns>
        string Execute(IList<string> parameters);
    }
}
