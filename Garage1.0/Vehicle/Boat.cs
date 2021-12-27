namespace Garage1._0
{
    public class Boat : Vehicle
    {
        public int Length { get; set; }
        public Boat(string RegistrationNumber, string Color, int NoOfWheels, VehicleType Type, int length)
            : base(RegistrationNumber, Color, NoOfWheels, Type)
        {
            this.Length = length;
        }
        public override string ToString() => $"Registration Number : {RegistrationNumber} - Color: {Color} - No of Wheels: {NoOfWheels} - " +
            $"Type : {Type} - Length: {Length} ";
    }
}
