namespace Garage1._0
{
    public class Car : Vehicle
    {
        public int NoOfEngine{ get; set; }

        public Car(string RegistrationNumber, string Color, int NoOfWheels, VehicleType Type, int NoOfEngine)
            : base(RegistrationNumber, Color, NoOfWheels, Type)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NoOfWheels = NoOfWheels;
            this.Type = Type;
            this.NoOfEngine = NoOfEngine;
        }
        public override string ToString() => $"Registration Number : {RegistrationNumber} - Color: {Color} - No of Wheels {NoOfWheels} - " +
            $"Type : {Type} - No of Engine {NoOfEngine} ";

    }
}
