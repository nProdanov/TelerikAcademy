using System;
using System.Collections.Generic;
using Cosmetics.Contracts;
using Cosmetics.Common;

namespace Cosmetics.Handlers
{
    public class CreateShampooHandler : ProcessingCommnadHandler
    {
        private const string ShampooAlreadyExist = "Shampoo with name {0} already exists!";
        private const string ShampooCreated = "Shampoo with name {0} was created!";

        public CreateShampooHandler(ICosmeticsFactory cosmeticsFactory)
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "CreateShampoo";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            var shampooName = command.Parameters[0];
            var shampooBrand = command.Parameters[1];
            var shampooPrice = decimal.Parse(command.Parameters[2]);
            var shampooGender = (GenderType)Enum.Parse(typeof(GenderType), this.UppercaseFirst(command.Parameters[3]));
            var shampooMilliliters = uint.Parse(command.Parameters[4]);
            var shampooUsage = (UsageType)Enum.Parse(typeof(UsageType), this.UppercaseFirst(command.Parameters[5]));

            if (products.ContainsKey(shampooName))
            {
                return string.Format(ShampooAlreadyExist, shampooName);
            }

            var shampoo = this.CosmeticsFactory.CreateShampoo(shampooName, shampooBrand, shampooPrice, shampooGender, shampooMilliliters, shampooUsage);
            products.Add(shampooName, shampoo);

            return string.Format(ShampooCreated, shampooName);
        }
    }
}
