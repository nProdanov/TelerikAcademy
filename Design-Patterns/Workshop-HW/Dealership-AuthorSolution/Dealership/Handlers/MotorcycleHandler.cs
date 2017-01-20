using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Handlers
{
    public class MotorcycleHandler : VehicleHandler
    {
        public MotorcycleHandler(IVehicleFactory vehicleFactory)
            : base(vehicleFactory)
        {
        }

        protected override bool CanHandle(VehicleType type)
        {
            return type == VehicleType.Motorcycle;
        }

        protected override IVehicle Handle(VehicleType type, string make, string model, decimal price, string additionalParam)
        {
            return this.VehicleFactory.GetMotorcycle(make, model, price, additionalParam);
        }
    }
}
