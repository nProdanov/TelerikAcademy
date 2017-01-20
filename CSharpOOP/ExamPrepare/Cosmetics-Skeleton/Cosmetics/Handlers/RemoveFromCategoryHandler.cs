using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Handlers
{
    public class RemoveFromCategoryHandler : ProcessingCommnadHandler
    {
        private const string ProductRemovedCategory = "Product {0} removed from category {1}!";

        public RemoveFromCategoryHandler(ICosmeticsFactory cosmeticsFactory)
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "RemoveFromCategory";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            var categoryNameToRemove = command.Parameters[0];
            var productToRemove = command.Parameters[1];

            if (!categories.ContainsKey(categoryNameToRemove))
            {
                return string.Format(CategoryDoesNotExist, categoryNameToRemove);
            }

            if (!products.ContainsKey(productToRemove))
            {
                return string.Format(ProductDoesNotExist, productToRemove);
            }

            var category = categories[categoryNameToRemove];
            var product = products[productToRemove];

            category.RemoveCosmetics(product);

            return string.Format(ProductRemovedCategory, productToRemove, categoryNameToRemove);
        }
    }
}
