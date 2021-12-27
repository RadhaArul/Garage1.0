namespace Garage1._0
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NoOfWheels { get; set; }
        public VehicleType Type { get; set; }
        public Vehicle(string RegistrationNumber, string Color, int NoOfWheels, VehicleType Type)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NoOfWheels = NoOfWheels;
            this.Type = Type;
        }
    }
}
