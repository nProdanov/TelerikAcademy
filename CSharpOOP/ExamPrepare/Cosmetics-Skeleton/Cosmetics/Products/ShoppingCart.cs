namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> products;
        private decimal totalprice;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
            this.totalprice = Constants.DefaultShoppingCartTotalPriceValue;
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format("Product to add {0}", Constants.ValidityMessageForNullObject));

            this.products.Add(product);
            this.totalprice += product.Price;
        }

        public bool ContainsProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format("Product {0}", Constants.ValidityMessageForNullObject));

            return this.products.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format("Product to remove {0}", Constants.ValidityMessageForNullObject));

            this.products.Remove(product);
            this.totalprice -= product.Price;
        }

        public decimal TotalPrice()
        {
            return this.totalprice;
        }
    }
}
