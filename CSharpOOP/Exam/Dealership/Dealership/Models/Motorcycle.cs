namespace Dealership.Models
{
    using Common;
    using Common.Enums;
    using Contracts;

    public class Motorcycle : Vehicle, IMotorcycle, ICommentable, IPriceable
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            this.Type = VehicleType.Motorcycle;
            this.Wheels = (int)this.Type;
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinCategoryLength,
                    Constants.MaxCategoryLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));

                this.category = value;
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), "Category", this.Category, "");
        }
    }
}
