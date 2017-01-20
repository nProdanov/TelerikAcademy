using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Handlers
{
    public abstract class VehicleHandler : IVehicleHandler
    {
        private IVehicleFactory vehicleFactory;

        public VehicleHandler(IVehicleFactory vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
        }

        public IVehicleFactory VehicleFactory
        {
            get
            {
                return this.vehicleFactory;
            }
        }

        private IVehicleHandler Successor { get; set; }

        public IVehicle HandleVehicle(VehicleType type, string make, string model, decimal price, string additionalParam)
        {
            if (this.CanHandle(type))
            {
                return this.Handle(type, make, model, price, additionalParam);
            }

            if (this.Successor != null)
            {
                return this.Successor.HandleVehicle(type, make, model, price, additionalParam);
            }

            return null;
        }

        public void SetSuccesor(IVehicleHandler succesor)
        {
            this.Successor = succesor;
        }

        protected abstract bool CanHandle(VehicleType type);

        protected abstract IVehicle Handle(VehicleType type, string make, string model, decimal price, string additionalParam);
    }
}
