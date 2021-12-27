using System.Collections.Generic;

namespace Garage1._0
{
    
    public interface IHandler<T> where T :  IVehicle
    {

        void Park(T item);
        bool Unpark(string str);
        
        T GetAll();
        List<T> GetByRegistrationNo(string id);
        List<T> GetByType(VehicleType type);
        T GetByColor(string color);
        T GetByWheels(int wheels);
        List<T> GroupbyType();
    }
}
