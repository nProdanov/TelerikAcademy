using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Handlers
{
    public class ShowCategoryHandler : ProcessingCommnadHandler
    {
        public ShowCategoryHandler(ICosmeticsFactory cosmeticsFactory)
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "ShowCategory";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            var categoryToShow = command.Parameters[0];

            if (!categories.ContainsKey(categoryToShow))
            {
                return string.Format(CategoryDoesNotExist, categoryToShow);
            }

            var category = categories[categoryToShow];

            return category.Print();
        }
    }
}
