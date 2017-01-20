using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Handlers
{
    public interface IVehicleHandler
    {
        void SetSuccesor(IVehicleHandler succesor);

        IVehicle HandleVehicle(VehicleType type, string make, string model, decimal price, string additionalParam);
    }
}
