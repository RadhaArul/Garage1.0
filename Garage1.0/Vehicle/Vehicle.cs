namespace Garage1._0
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public uint NoOfWheels { get; set; }
        public string Type { get; set; }
        public Vehicle(string RegistrationNumber, string Color, uint NoOfWheels, string Type)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NoOfWheels = NoOfWheels;
            this.Type = Type;
        }
    }
}
