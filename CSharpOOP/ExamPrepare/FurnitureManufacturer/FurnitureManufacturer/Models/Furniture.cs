namespace FurnitureManufacturer.Models
{
    using System.Text;

    using Interfaces;

    public class Furniture : IFurniture
    {
        protected const int MinModelLength = 3;
        protected decimal height;
        protected string material;
        protected string model;
        protected decimal price;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                Validator.CheckForPositiveDecimal(value, "height", "m");

                this.height = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }
            protected set
            {
                switch (value)
                {
                    case "wooden": this.material = MaterialType.Wooden.ToString();
                        break;
                    case "leather": this.material = MaterialType.Leather.ToString();
                        break;
                    case "plastic": this.material = MaterialType.Plastic.ToString();
                        break;
                }
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
                Validator.CheckIfStringIsNullOrEmpty(value, "Model can not be a null or empty!");
                Validator.CheckIfMinStringLengthIsValid(value, Furniture.MinModelLength, "Minimal model's length is 3 symbols!");

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                Validator.CheckForPositiveDecimal(value, "Price", "$");

                this.price = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name, 
                this.Model,
                this.Material,
                this.Price, 
                this.Height));

            return result.ToString();
        }
    }
}
