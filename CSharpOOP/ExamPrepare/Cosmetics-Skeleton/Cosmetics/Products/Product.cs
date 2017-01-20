namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        protected string brand;
        protected GenderType gender;
        protected string name;
        protected decimal price;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format("Brand {0}", Constants.ValidityMessageForNullOrEmptyString));
                Validator.CheckIfStringLengthIsValid(
                    value, 
                    Constants.MaxLettersProductBrandLength, 
                    Constants.MinLettersProductBrandLength, 
                    string.Format("Product brand must be between {0} and {1} symbols long!", Constants.MinLettersProductBrandLength, Constants.MaxLettersProductBrandLength));

                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            protected set
            {
                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format("Name {0}", Constants.ValidityMessageForNullOrEmptyString));
                Validator.CheckIfStringLengthIsValid(
                    value,
                    Constants.MaxLettersProductNameLength, 
                    Constants.MinLettersProductNameLength, 
                    string.Format("Product name must be between {0} and {1} symbols long!", Constants.MinLettersProductNameLength, Constants.MaxLettersProductNameLength));

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price", "Price must be a positive value!");
                }

                this.price = value;
            }
        }

        public virtual string Print()
        {
            var strForPrint = new StringBuilder();
            strForPrint.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            strForPrint.AppendLine(string.Format("  * Price: ${0}", this.Price));
            strForPrint.Append(string.Format("  * For gender: {0}", this.Gender));

            return strForPrint.ToString();
        }
    }
}
