namespace Dealership.Models
{
    using System;
    using Common;
    using Common.Enums;
    using Contracts;

    public class Truck : Vehicle, ITruck, IPriceable, ICommentable
    {
        private int weigthCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) 
            : base(make, model, price)
        {
            this.Type = VehicleType.Truck;
            this.Wheels = (int)this.Type;
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weigthCapacity;
            }
            private set
            {
                Validator.ValidateIntRange(
                    value, 
                    Constants.MinCapacity, 
                    Constants.MaxCapacity, 
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));

                this.weigthCapacity = value;
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), "Weight Capacity", this.WeightCapacity, "t");
        }
    }
}
