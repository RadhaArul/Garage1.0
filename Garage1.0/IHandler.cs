using System.Collections.Generic;

namespace Garage1._0
{
    
    public interface IHandler<T> where T :  IVehicle
    {

        public void ParkVehicle(T item);
        public void PickUpVehicle(T item);
        T GetAll();
        T GetByRegistrationNo(T[] item, string id);
        T GetByType(VehicleType type);
        T GetByColor(string color);
        T GetByWheels(int wheels);
    }
}
