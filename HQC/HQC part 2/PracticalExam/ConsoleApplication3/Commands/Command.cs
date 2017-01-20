using System.Collections.Generic;

using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public abstract class Command : ICommand
    {
        private IEngine engine;

        public Command()
        {
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }

            set
            {
                this.engine = value;
            }
        }

        public abstract string Execute(IList<string> parameters);
    }
}
