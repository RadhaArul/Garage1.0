namespace Garage1._0
{
    public class Airplane : Vehicle
    {
        public int NoOfSeats { get; set; }
        public Airplane(string RegistrationNumber, string Color, int NoOfWheels, VehicleType Type, int NoOfSeats )
            :base(RegistrationNumber,Color,NoOfWheels,Type)
        {
            this.NoOfSeats = NoOfSeats;
        }
        public override string ToString() => $"Registration Number : {RegistrationNumber} - Color: {Color} - No of Wheels: {NoOfWheels} - " +
            $"Type : {Type} - No of Seats: {NoOfSeats} ";

    }
}
