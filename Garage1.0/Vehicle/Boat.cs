namespace Garage1._0
{
    public class Boat : Vehicle
    {
        public uint Length { get; set; }
        public Boat(string RegistrationNumber, string Color, uint NoOfWheels, string Type, uint length)
            : base(RegistrationNumber, Color, NoOfWheels, Type)
        {
            this.Length = length;
        }
        public override string ToString() => $"Registration Number : {RegistrationNumber} Color: {Color} No of Wheels{NoOfWheels} " +
            $"Type : {Type} Length {Length} ";
    }
}
