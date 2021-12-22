namespace Garage1._0
{
    public class Bus : Vehicle
    {
        public FuelType FuelType { get; set; }
        public Bus(string RegistrationNumber, string Color, uint NoOfWheels, VehicleType Type, FuelType fuelType)
            : base(RegistrationNumber, Color, NoOfWheels, Type)
        {
            this.FuelType = fuelType;
        }
        public override string ToString() => $"Registration Number : {RegistrationNumber} Color: {Color} No of Wheels{NoOfWheels}" +
            $" Type : {Type} FuelType {FuelType}";

    }
}
