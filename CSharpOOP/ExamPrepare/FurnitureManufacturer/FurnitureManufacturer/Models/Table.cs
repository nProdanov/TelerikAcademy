namespace FurnitureManufacturer.Models
{
    using System.Text;

    using Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;
        private decimal area;

        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width) 
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
            this.area = this.Length * this.Width;
        }

        public decimal Area
        {
            get
            {
                return this.area;
            }
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                Validator.CheckForPositiveDecimal(value, "length", "m");

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                Validator.CheckForPositiveDecimal(value, "width", "m");

                this.width = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area));

            return result.ToString();
        }
    }
}
