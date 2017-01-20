using System.Collections.Generic;

namespace Cosmetics.Contracts
{
    public interface IProcessCommandHandler
    {
        string HandleProcess(
            ICommand command,
            IShoppingCart shoppingCart,
            IDictionary<string, ICategory> categories,
            IDictionary<string, IProduct> products);

        void SetSuccessor(IProcessCommandHandler successor);
    }
}
