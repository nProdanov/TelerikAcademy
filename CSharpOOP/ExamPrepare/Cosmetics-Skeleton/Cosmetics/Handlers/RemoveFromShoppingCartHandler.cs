using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Handlers
{
    public class RemoveFromShoppingCartHandler : ProcessingCommnadHandler
    {
        private const string ProductDoesNotExistInShoppingCart = "Shopping cart does not contain product with name {0}!";
        private const string ProductRemovedFromShoppingCart = "Product {0} was removed from the shopping cart!";

        public RemoveFromShoppingCartHandler(ICosmeticsFactory cosmeticsFactory) 
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "RemoveFromShoppingCart";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            var productToRemoveFromCart = command.Parameters[0];

            if (!products.ContainsKey(productToRemoveFromCart))
            {
                return string.Format(ProductDoesNotExist, productToRemoveFromCart);
            }

            var product = products[productToRemoveFromCart];

            if (!shoppingCart.ContainsProduct(product))
            {
                return string.Format(ProductDoesNotExistInShoppingCart, productToRemoveFromCart);
            }

            shoppingCart.RemoveProduct(product);

            return string.Format(ProductRemovedFromShoppingCart, productToRemoveFromCart);
        }
    }
}
