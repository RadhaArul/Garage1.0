using System;
namespace Garage1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage<IVehicle> Parking = new Garage<IVehicle>();
            Parking.Run();
        }
    }
}
