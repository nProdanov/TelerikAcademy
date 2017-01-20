using Cosmetics.Contracts;
using System.Collections.Generic;

namespace Cosmetics.Handlers
{
    public abstract class ProcessingCommnadHandler : IProcessCommandHandler
    {
        private const string InvalidCommand = "Invalid command name: {0}!";

        protected const string CategoryDoesNotExist = "Category {0} does not exist!";
        protected const string ProductDoesNotExist = "Product {0} does not exist!";

        private ICosmeticsFactory cosmeticsFactory;
        private IProcessCommandHandler successor;

        public ProcessingCommnadHandler(ICosmeticsFactory cosmeticsFactory)
        {
            this.cosmeticsFactory = cosmeticsFactory;
        }

        protected ICosmeticsFactory CosmeticsFactory
        {
            get
            {
                return this.cosmeticsFactory;
            }
        }

        public void SetSuccessor(IProcessCommandHandler successor)
        {
            this.successor = successor;
        }

        public string HandleProcess(
            ICommand command,
            IShoppingCart shoppingCart,
            IDictionary<string, ICategory> categories,
            IDictionary<string, IProduct> products)
        {
            if (this.CanHandle(command.Name))
            {
                return this.Handle(command, shoppingCart, categories, products);
            }

            if (this.successor != null)
            {
                return this.successor.HandleProcess(command, shoppingCart, categories, products);
            }

            return string.Format(InvalidCommand, command.Name);
        }

        protected abstract bool CanHandle(string commandName);

        protected abstract string Handle(
            ICommand command,
            IShoppingCart shoppingCart,
            IDictionary<string, ICategory> categories,
            IDictionary<string, IProduct> products);

        protected string UppercaseFirst(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
