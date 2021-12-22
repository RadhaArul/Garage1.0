namespace Garage1._0
{
    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Color { get; set; }
        uint NoOfWheels { get; set; }
        string Type { get; set; }
    }
}
