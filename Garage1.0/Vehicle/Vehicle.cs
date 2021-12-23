namespace Garage1._0
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public uint NoOfWheels { get; set; }
        public VehicleType Type { get; set; }
        public Vehicle(string RegistrationNumber, string Color, uint NoOfWheels, VehicleType Type)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NoOfWheels = NoOfWheels;
            this.Type = Type;
        }
    }
}
