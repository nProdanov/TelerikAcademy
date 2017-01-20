using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Handlers
{
    public class AddToShoppingCartHandler : ProcessingCommnadHandler
    {
        private const string ProductAddedToShoppingCart = "Product {0} was added to the shopping cart!";

        public AddToShoppingCartHandler(ICosmeticsFactory cosmeticsFactory) 
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "AddToShoppingCart";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            var productToAddToCart = command.Parameters[0];

            if (!products.ContainsKey(productToAddToCart))
            {
                return string.Format(ProductDoesNotExist, productToAddToCart);
            }

            var product = products[productToAddToCart];
            shoppingCart.AddProduct(product);

            return string.Format(ProductAddedToShoppingCart, productToAddToCart);
        }
    }
}
