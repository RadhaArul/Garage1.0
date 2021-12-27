namespace Garage1._0
{
    public class Motorcycle : Vehicle
    {
        public string CylinderVolume { get; set; }
        public Motorcycle(string RegistrationNumber, string Color, int NoOfWheels, VehicleType Type, string cylinderVolume)
           : base(RegistrationNumber, Color, NoOfWheels, Type)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Color = Color;
            this.NoOfWheels = NoOfWheels;
            this.Type = Type;
            this.CylinderVolume = cylinderVolume;
        }
        public override string ToString() => $"Registration Number : {RegistrationNumber} - Color: {Color} - No of Wheels: {NoOfWheels} - " +
            $"Type : {Type} - Cylinder Volume: {CylinderVolume}";

    }
}
