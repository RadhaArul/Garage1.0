namespace Garage1._0
{
    public class Car : Vehicle
    {
        public uint NoOfEngine{ get; set; }

        public Car(string RegistrationNumber, string Color, uint NoOfWheels, string Type, uint NoOfEngine)
            : base(RegistrationNumber, Color, NoOfWheels, Type)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NoOfWheels = NoOfWheels;
            this.Type = Type;
            this.NoOfEngine = NoOfEngine;
        }
        public override string ToString() => $"Registration Number : {RegistrationNumber} Color: {Color} No of Wheels{NoOfWheels} " +
            $"Type : {Type}No of Engine {NoOfEngine} ";

    }
}
