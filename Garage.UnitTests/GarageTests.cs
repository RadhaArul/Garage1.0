using Garage1._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage.UnitTests
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void resize_TestMethod1()
        {
            //Arrange
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            var size = 15;
            var expected = 15;
            //Act
            V.resize(size);
            var actual = V.Capacity;
            
            //Assert
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void resize_ifNegative_throws()
        {
            //Arrange and Act
            var size = -1;
            Garage<IVehicle> V = new Garage<IVehicle>(10);

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => V.resize(size));
        }

        [TestMethod]
        public void Park_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C=new Car("ABC123", "Silver", 4, VehicleType.Car, 2);
            
            //Assert
            Assert.IsTrue(V.Park(C));
        }
        [TestMethod]
        public void Park_ByWrongRegNo_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("ABC123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            Car C1 =new Car("ABC123", "Silver", 4, VehicleType.Car, 2);
            
            //Assert
            Assert.IsFalse(V.Park(C1));
        }

        [TestMethod]
        public void Garage_Full_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(1);
            Car C = new Car("ABC123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            Car C1 = new Car("ABC123", "Silver", 4, VehicleType.Car, 2);

            //Assert
            Assert.IsFalse(V.Park(C1));
        }
        [TestMethod]
        public void UnPark_Exist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("ABC123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            string reg = "ABC123";

            //Assert
            Assert.IsTrue(V.Unpark(reg));
        }

        [TestMethod]
        public void UnPark_NotExist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("ABC123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            string reg = "AB123";

            //Assert
            Assert.IsFalse(V.Unpark(reg));
        }

        [TestMethod]
        public void GetByRegistrationNo_Exist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("abc123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            string reg = "ABC123";
            List<IVehicle> vehicle = V.GetByRegistrationNo(reg);
            var expected = 1;
            var actual = vehicle.Count;
            //Assert
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void GetByRegistrationNo_NotExist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("abc123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            string reg = "AB123";
            List<IVehicle> vehicle = V.GetByRegistrationNo(reg);
            var actual = vehicle.Count;
            var expected = 0;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByType_Exist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("abc123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            VehicleType t = VehicleType.Car;
            List<IVehicle> vehicle = V.GetByType(t);
            var actual = vehicle.Count;
            var expected = 1;
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetByType_NotExist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("abc123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            VehicleType t = VehicleType.Bus;
            List<IVehicle> vehicle = V.GetByType(t);
            var actual = vehicle.Capacity;
            var expected = 0;
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetByColor_Exist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("abc123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            List<IVehicle> vehicle = V.GetByColor("SILVER");
            var actual = vehicle.Count;
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByColor_NotExist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("abc123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            List<IVehicle> vehicle = V.GetByColor("Red");
            var actual = vehicle.Capacity;
            var expected = 0;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetByWheels_Exist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("abc123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            List<IVehicle> vehicle = V.GetByWheels(4);
            var actual = vehicle.Count;
            var expected = 1;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetByWheels_NotExist_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> V = new Garage<IVehicle>(10);
            Car C = new Car("abc123", "Silver", 4, VehicleType.Car, 2);
            V.Park(C);
            List<IVehicle> vehicle = V.GetByWheels(8);
            var actual = vehicle.Capacity;
            var expected = 0;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAll_TestMethod()
        {
            //Arrange and Act
            Garage<IVehicle> vh = new Garage<IVehicle>(10);
            vh.Park(new Car("ABC123", "Silver", 4, VehicleType.Car, 2));
            vh.Park(new Car("bcd234", "Red", 4, VehicleType.Car, 1));
            vh.Park(new Bus("Tyg123456", "Blue", 8, VehicleType.Bus, FuelType.Diesel));
            vh.Park(new Bus("FRG345678", "Green", 6, VehicleType.Bus, FuelType.Gasoline));
            vh.Park(new Boat("SL456", "White", 0, VehicleType.Boat, 100));
            vh.Park(new Motorcycle("th321", "yellow", 2, VehicleType.Motorcycle, "150cc"));
            vh.Park(new Airplane("AI360", "yellow", 10, VehicleType.Airplane, 200));

            var expected = 7;
            var VA = vh.GetAll();
            var result = VA
                .Where(x => x?.RegistrationNumber != null);

            var actual = result.ToList().Count;

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
