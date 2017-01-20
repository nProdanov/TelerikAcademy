using System;
using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Handlers
{
    public class AddToCategoryHandler : ProcessingCommnadHandler
    {
        private const string ProductAddedToCategory = "Product {0} added to category {1}!";

        public AddToCategoryHandler(ICosmeticsFactory cosmeticsFactory)
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "AddToCategory";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            var categoryNameToAdd = command.Parameters[0];
            var productToAdd = command.Parameters[1];

            if (!categories.ContainsKey(categoryNameToAdd))
            {
                return string.Format(CategoryDoesNotExist, categoryNameToAdd);
            }

            if (!products.ContainsKey(productToAdd))
            {
                return string.Format(ProductDoesNotExist, productToAdd);
            }

            var category = categories[categoryNameToAdd];
            var product = products[productToAdd];

            category.AddCosmetics(product);

            return string.Format(ProductAddedToCategory, productToAdd, categoryNameToAdd);
        }
    }
}
