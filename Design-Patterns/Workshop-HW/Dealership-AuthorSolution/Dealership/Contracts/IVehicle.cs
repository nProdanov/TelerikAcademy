namespace Dealership.Contracts
{
    using Dealership.Common.Enums;

    public interface IVehicle : ICommentable, IPriceable
    {
        void SetSuccessor(IVehicle successor);

        int Wheels { get; }

        VehicleType Type { get; }

        string Make { get; }

        string Model { get;  }
    }
}
