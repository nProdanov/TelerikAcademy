namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;
    
    public class Shampoo : Product, IShampoo, IProduct
    {
        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price = this.Price * this.Milliliters;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            private set
            {
                if(value == 0)
                {
                    throw new ArgumentOutOfRangeException("Milliliters", "Milliliters can not be a zero!");
                }

                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            private set
            {
                this.usage = value;
            }
        }

        public override string Print()
        {
            var strForPrint = new StringBuilder();
            strForPrint.AppendLine(base.Print());
            strForPrint.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            strForPrint.Append(string.Format("  * Usage: {0}", this.Usage));

            return strForPrint.ToString();
        }
    }
}
