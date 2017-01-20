namespace Dealership.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Common;
    using Contracts;
    using Common.Enums;

    public abstract class Vehicle : IVehicle, ICommentable, IPriceable
    {
        private const int PrintDashesSeparaterCount = 10;
        protected IList<IComment> comments;
        protected string make;
        protected string model;
        protected decimal price;
        protected VehicleType type;
        protected int wheels;

        public Vehicle(string make, string model, decimal price)
        {
            this.comments = new List<IComment>();
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            protected set
            {
                Validator.ValidateNull(
                    value, 
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinMakeLength,
                    Constants.MaxMakeLength, 
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                Validator.ValidateNull(value, string.Format(Constants.StringMustBeBetweenMinAndMax, "Model", Constants.MinModelLength, Constants.MaxModelLength));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinModelLength,
                    Constants.MaxModelLength, 
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Model", Constants.MinModelLength, Constants.MaxModelLength));

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                Validator.ValidateDecimalRange(
                    value,
                    Constants.MinPrice,
                    Constants.MaxPrice,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Price", Constants.MinPrice, Constants.MaxPrice));

                this.price = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            protected set
            {
                this.type = value;
            }
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            protected set
            {
                Validator.ValidateIntRange(
                    value,
                    Constants.MinWheels, 
                    Constants.MaxWheels, 
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Wheels", Constants.MinWheels, Constants.MaxWheels));

                this.wheels = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("{0}:", this.Type));
            result.AppendLine(string.Format("  Make: {0}", this.Make));
            result.AppendLine(string.Format("  Model: {0}", this.Model));
            result.AppendLine(string.Format("  Wheels: {0}", this.Wheels));
            result.AppendLine(string.Format("  Price: ${0}", this.Price));
            result.AppendLine("  {0}: {1}{2}");
            if (this.Comments.Count ==0)
            {
                result.Append("    --NO COMMENTS--");
                return result.ToString();
            }
            string separator = string.Format("    {0}", new string('-', Vehicle.PrintDashesSeparaterCount));

            result.AppendLine("    --COMMENTS--");
            foreach (var comment in this.Comments)
            {
                result.AppendLine(separator);
                result.AppendLine(comment.ToString());
                result.AppendLine(separator);
            }

            result.Append("    --COMMENTS--");

            return result.ToString();
        }
    }
}
