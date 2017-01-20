using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Handlers
{
    public class CarHandler : VehicleHandler
    {
        public CarHandler(IVehicleFactory vehicleFactory)
            : base(vehicleFactory)
        {
        }

        protected override bool CanHandle(VehicleType type)
        {
            return type == VehicleType.Car;
        }

        protected override IVehicle Handle(VehicleType type, string make, string model, decimal price, string additionalParam)
        {
            return this.VehicleFactory.GetCar(make, model, price, int.Parse(additionalParam));
        }
    }
}
