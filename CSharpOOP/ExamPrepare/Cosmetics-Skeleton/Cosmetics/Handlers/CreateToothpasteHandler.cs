using System;
using System.Collections.Generic;
using Cosmetics.Contracts;
using Cosmetics.Common;
using System.Linq;

namespace Cosmetics.Handlers
{
    public class CreateToothpasteHandler : ProcessingCommnadHandler
    {
        private const string ToothpasteAlreadyExist = "Toothpaste with name {0} already exists!";
        private const string ToothpasteCreated = "Toothpaste with name {0} was created!";

        public CreateToothpasteHandler(ICosmeticsFactory cosmeticsFactory)
            : base(cosmeticsFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "CreateToothpaste";
        }

        protected override string Handle(ICommand command, IShoppingCart shoppingCart, IDictionary<string, ICategory> categories, IDictionary<string, IProduct> products)
        {
            var toothpasteName = command.Parameters[0];
            var toothpasteBrand = command.Parameters[1];
            var toothpastePrice = decimal.Parse(command.Parameters[2]);
            var toothpasteGender = (GenderType)Enum.Parse(typeof(GenderType), this.UppercaseFirst(command.Parameters[3]));
            var toothpasteIngredients = command.Parameters[4].Trim().Split(',').ToList();

            if (products.ContainsKey(toothpasteName))
            {
                return string.Format(ToothpasteAlreadyExist, toothpasteName);
            }

            var toothpaste = this.CosmeticsFactory.CreateToothpaste(toothpasteName, toothpasteBrand, toothpastePrice, toothpasteGender, toothpasteIngredients);
            products.Add(toothpasteName, toothpaste);

            return string.Format(ToothpasteCreated, toothpasteName);
        }
    }
}
