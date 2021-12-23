namespace Garage1._0
{
    public interface IVehicle
    {
        string RegistrationNumber { get; }
        string Color { get; }
        uint NoOfWheels { get; }
        VehicleType Type { get; }
    }
}
