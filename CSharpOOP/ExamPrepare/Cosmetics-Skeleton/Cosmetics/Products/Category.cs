namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private string name;
        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format("Name {0}", Constants.ValidityMessageForNullOrEmptyString));
                Validator.CheckIfStringLengthIsValid(
                    value,
                    Constants.MaxLettersCategoryName, 
                    Constants.MinLettersCategoryName, 
                    string.Format("Category name must be between {0} and {1} symbols long!", Constants.MinLettersCategoryName, Constants.MaxLettersCategoryName));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format("Cosmetic product for add {0}", Constants.ValidityMessageForNullObject));
            this.products.Add(cosmetics);
        }

        public string Print()
        {
            var productsCount = this.products.Count;

            var strForPrint = new StringBuilder();
            strForPrint.Append(string.Format(
                "{0} category - {1} {2} in total", 
                this.Name, 
                productsCount,
                productsCount == 1 ? "product" : "products"));

            if(productsCount == 0)
            {
                return strForPrint.ToString();
            }

            var orderedProducts = this.products.
                OrderBy(p => p.Brand).
                ThenByDescending(p => p.Price);

            strForPrint.AppendLine();
            foreach(var prod in orderedProducts)
            {
                strForPrint.AppendLine(prod.Print());
            }

            return strForPrint.ToString().TrimEnd();
            
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format("Cosmetic product for remove {0}", Constants.ValidityMessageForNullObject));
            this.products.Remove(cosmetics);
        }
    }
}
