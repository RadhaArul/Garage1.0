
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage1._0
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private  T[] vehicles;
        public T this[int index] => vehicles[index];
        public Garage(int capacity)
        {
            vehicles = new T[capacity];
        }
        public void resize(int size)
        {
            Array.Resize(ref vehicles, size);
        }
        public int Capacity => vehicles.Length;
        public  bool Park(T vehicle)
        {
            var check = Array.Find(vehicles, v => v?.RegistrationNumber.ToUpper() == vehicle.RegistrationNumber.ToUpper());
            if(check==null)
            { 
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    break;
                }
            }
                return true;
            }
            return false;
        }
        public  bool Unpark(string regnr) 
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i]!=null && (vehicles[i].RegistrationNumber.ToLower() == regnr.ToLower()))
                {
                    vehicles[i] = default(T);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator() // Keep
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null) yield return vehicles[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
        public List<T> GetByRegistrationNo(string id)
        {
            var vehicle = vehicles
                 .Where(v => v?.RegistrationNumber.ToUpper() == id.ToUpper())
                 .ToList();
            return vehicle;
        }

        public List<T> GetByType(VehicleType type)
        {
            var vehicle = vehicles
                .Where(v => v?.Type == type)
                .ToList();
            return vehicle;
        }

        public List<T> GetByColor(string color)
        {
            var vehicle = vehicles
                .Where(v => v?.Color.ToUpper() == color.ToUpper())
                .ToList();
            return vehicle;
        }

        public List<T> GetByWheels(int wheels)
        {
            var vehicle = vehicles
               .Where(v => v?.NoOfWheels==wheels)
               .ToList();
            return vehicle;
        }
        

        public T[] GetAll() => vehicles;


    }
}
