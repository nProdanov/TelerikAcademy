using System;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Handlers
{
    public class TruckHandler : VehicleHandler
    {
        public TruckHandler(IVehicleFactory vehicleFactory) 
            : base(vehicleFactory)
        {
        }

        protected override bool CanHandle(VehicleType type)
        {
            return type == VehicleType.Truck;
        }

        protected override IVehicle Handle(VehicleType type, string make, string model, decimal price, string additionalParam)
        {
            return this.VehicleFactory.GetTruck(make, model, price, int.Parse(additionalParam));
        }
    }
}
