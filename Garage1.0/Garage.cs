
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage1._0
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private static T[] garage = new T[2];
        private static int GarageFull = 2;
        private static IUI ui;
        IHandler<T> obj;
        public static int counter { get; protected set; }
        public T this[int index] => garage[index];
        public static int GarageCount;
        public void Run()
        {
            counter = 0;
            
            ui = new ConsoleUI();
            do
            {
                Console.Clear();
                MainMenu();
                Input();
            } while (true);
        }

        private static void Input()
        {
            string UserInput = ui.AskForStrInput("Enter your Choice");
            switch (UserInput)
            {
                case "1":
                    InstallGarage();
                    break;
                case "2":
                    ManageMenu();
                    ManageInput();
                    break;
                case "3":
                    SearchMenu();
                    SearchInput();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    ui.PrintString("Invalid Input! Press Enter to Try Again");
                    ui.Rkey();
                    break;
            }
        }

        

        private static void InstallGarage()
        {
            uint size = ui.AskForUIntInput("Enter the Size of Garage to Install");
            //garage = new(size);
            ui.PrintString($"Garage of size {size} Installed Successfully");
        }
        private static void MainMenu()
        {
            ui.PrintString("1.Install a New Garage");
            ui.PrintString("2.Manage Vehicle");
            ui.PrintString("3.Search Vehicle");
            ui.PrintString("0.Exit");
        }
        private static void SearchMenu()
        {
            ui.PrintString("1. View All Parked Vehicle");
            ui.PrintString("2. View All Vehicles by Type");
            ui.PrintString("3. View by Registration Number");
            ui.PrintString("4. View by Color");
            ui.PrintString("5. View by No of Wheels");
            ui.PrintString("0. Go Back to MainMenu");
        }
        private static void SearchInput()
        {
            string input = ui.AskForStrInput("Enter Your Choice");
            switch (input)
            {
                case "1":
                    ViewAll();
                    break;
                case "2":
                case "3":
                    Garage<T> o=new Garage<T>();
                    var veh = o.GetByRegistrationNo(garage, "a12");
                    Console.WriteLine(veh.ToString());
                    break;
                case "0":
                    break;
                default:
                    ui.PrintString("Invalid Input! Press Enter to Try Again");
                    ui.Rkey();
                    break;
            }

        }

        private static void ViewAll()
        {
            ui.PrintString("Parked vehicles are");
            //foreach (var item in garage)
            //{
            //    if (item != null) ui.PrintString(item.ToString());
            //}
            for (int i = 0; i < 2; i++)
            {
                if (garage[i] == null)
                    ui.PrintString($"{i}.\tFree space");
                else
                    ui.PrintString($"{i}.\t{garage[i]}");
            }
            
            ui.Rkey();
        }

        private static void ManageMenu()
        {
            ui.PrintString("1. Park Vehicle/Check In");
            ui.PrintString("2. Pickup Vehicle/Check Out");
            ui.PrintString("0. Go Back to MainMenu");
        }
        private static void ManageInput()
        {
            string input = ui.AskForStrInput("Enter Your Choice");
            
            switch (input)
            {
                case "1":
                     GarageCount = Array.FindAll(garage, s => s== null).Length;
                    if (GarageCount>0)
                        ShowVehicle();
                    else
                    {
                        ui.PrintString("Garage Full... There is No Parking Slot Press Enter to go back");
                        ui.Rkey();
                    }
                    break;
                case "2":
                case "0":
                    break;
                default:
                    ui.PrintString("Invalid Input! Press Enter to Try Again");
                    ui.Rkey();
                    break;
            }
        }

        private static void ShowVehicle()
        {
            ui.PrintString("1.Park a Car");
            ui.PrintString("2.Park a Bus");
            ui.PrintString("3.Park a Boat");
            ui.PrintString("4.Park a Motorcycle");
            ui.PrintString("5.Park a Airplane");
            ui.PrintString("0.Go Back to Main Menu");
            string answer = ui.AskForStrInput("Enter your Choice");
            switch (answer)
            {
                case "1":
                    ParkCar();
                    break;
                case "2":
                    ParkBus();
                    break;
                case "3":
                    ParkBoat();
                    break;
                case "4":
                    ParkMotorcycle();
                    break;
                case "5":
                    ParkAirplane();
                    break;
                case "0":
                    break;
                default:
                    ui.PrintString("Invalid Input! Press Enter to Try Again");
                    ui.Rkey();
                    break;
            }
        }

        private static void ParkAirplane()
        {
            throw new NotImplementedException();
        }

        private static void ParkMotorcycle()
        {
            throw new NotImplementedException();
        }

        private static void ParkBoat()
        {
            throw new NotImplementedException();
        }

        private static void ParkBus()
        {
            (string RegistrationNumber, string Color, uint NoOfWheels) = GetCommonFeatures();
            ui.PrintString("Enter Fuel Type");
            foreach (var FT in Enum.GetValues(typeof(FuelType)))
                ui.PrintString($"{(int)FT} - {FT}");
            int Ftype=ui.AskForFuelInput();
            Bus bus = new Bus(RegistrationNumber, Color, NoOfWheels, VehicleType.Bus, (FuelType)Ftype);
            var b = new Garage<Bus>();
            b.ParkVehicle(bus);
            ui.PrintString("Your Bus is Successfully Parked");
            ui.Rkey();
        }

        private static void ParkCar()
        {
            (string RegistrationNumber, string Color, uint NoOfWheels) = GetCommonFeatures();
            uint NE = ui.AskForUIntInput("Enter Number of Engines");
            Car car = new Car(RegistrationNumber,Color,NoOfWheels,VehicleType.Car,NE);
            var c = new Garage<Car>();
            c.ParkVehicle(car);
            ui.PrintString("Your Car is Successfully Parked");
            ui.Rkey();
        }

        private static (string, string, uint) GetCommonFeatures()
        {
            string RegNo = ui.AskForStrInput("Registration Number ");
            string Col = ui.AskForStrInput("Color ");
            uint NofW = ui.AskForUIntInput("Number of Wheels ");
            return (RegNo, Col, NofW);
        }


        //public Garage(uint sizeofGarage)
        //{
        //    garage = new T[sizeofGarage];
        //}

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        

        public IEnumerable<T> GetAll()
        {
            return garage;
        }

        public T GetByRegistrationNo(T[] item, string id)
        {
            return Array.Find(item, veh => veh.RegistrationNumber.ToUpper() == id.ToUpper());
        }

        public T GetByType(VehicleType type)
        {
            throw new NotImplementedException();
        }

        public T GetByColor(string color)
        {
            throw new NotImplementedException();
        }

        public T GetByWheels(int wheels)
        {
            throw new NotImplementedException();
        }

        public void ParkVehicle(T item)
        {
                garage[counter] = (T)item;
                Console.WriteLine(garage[counter].ToString());
                ++counter;
        }

        public void PickUpVehicle(T item)
        {
            throw new NotImplementedException();
        }

        
    }
}
