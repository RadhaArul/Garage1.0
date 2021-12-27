namespace Garage1._0
{
    public interface IVehicle
    {
        string RegistrationNumber { get; }
        string Color { get; }
        int NoOfWheels { get; }
        VehicleType Type { get; }
    }
}
