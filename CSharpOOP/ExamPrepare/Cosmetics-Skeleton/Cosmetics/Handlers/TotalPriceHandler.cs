using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Handlers
{
    public class TotalPriceHandler : ProcessingCommnadHandler
    {
        private const string TotalPriceInShoppingCart = "${0} total price currently in the shopping cart!";

        public TotalPriceHandler(ICosmeticsFactory cosmeticsFactory)
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "TotalPrice";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            return string.Format(TotalPriceInShoppingCart, shoppingCart.TotalPrice());
        }
    }
}
