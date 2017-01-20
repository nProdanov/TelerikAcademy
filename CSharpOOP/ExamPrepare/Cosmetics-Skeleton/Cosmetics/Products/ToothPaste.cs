namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using Contracts;
    
    public class ToothPaste : Product, IToothpaste, IProduct
    {
        private string ingredients;

        public ToothPaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            foreach(var ingr in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(
                    ingr, 
                    Constants.MaxLettersIngradientLength, 
                    Constants.MinLettersIngradientLength, 
                    string.Format("Each ingredient must be between {0} and {1} symbols long!", Constants.MinLettersIngradientLength, Constants.MaxLettersIngradientLength));
            }

            this.ingredients = string.Join(", ", ingredients);
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        public override string Print()
        {
            var strForPrint = new StringBuilder();
            strForPrint.AppendLine(base.Print());
            strForPrint.Append(string.Format("  * Ingredients: {0}", this.ingredients));

            return strForPrint.ToString();
        }
    }
}
