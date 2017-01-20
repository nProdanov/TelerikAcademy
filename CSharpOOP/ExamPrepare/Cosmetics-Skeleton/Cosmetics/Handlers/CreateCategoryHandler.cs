using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Handlers
{
    public class CreateCategoryHandler : ProcessingCommnadHandler
    {
        private const string CategoryExists = "Category with name {0} already exists!";
        private const string CategoryCreated = "Category with name {0} was created!";

        public CreateCategoryHandler(ICosmeticsFactory cosmeticsFactory)
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "CreateCategory";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            var categoryName = command.Parameters[0];

            if (categories.ContainsKey(categoryName))
            {
                return string.Format(CategoryExists, categoryName);
            }

            var category = this.CosmeticsFactory.CreateCategory(categoryName);
            categories.Add(categoryName, category);

            return string.Format(CategoryCreated, categoryName);
        }
    }
}
