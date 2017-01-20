namespace Dealership.Models
{
    using Common;
    using Common.Enums;
    using Contracts;

    public class Car : Vehicle, ICar, ICommentable, IPriceable
    {
        private int seats;

        public Car(string make, string model, decimal price, int seats) 
            : base(make, model, price)
        {
            this.Type = VehicleType.Car;
            this.Wheels = (int)this.Type;
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            private set
            {
                Validator.ValidateIntRange(
                    value,
                    Constants.MinSeats,
                    Constants.MaxSeats, 
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Seats", Constants.MinSeats, Constants.MaxSeats));

                this.seats = value;
            }
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), "Seats", this.Seats, "");
        }
    }
}
