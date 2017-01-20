namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using Interfaces;

    public class Chair : Furniture, IChair
    {
        protected int numberOfLegs;

        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("number of legs", "Number of legs can not be a less or equal to 0!");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(string.Format(", Legs: {0}", this.NumberOfLegs));

            return result.ToString();
        }
    }
}
