
using System;
using System.Collections;
using System.Collections.Generic;
namespace Garage1._0
{
    public class Garage<T> : IEnumerable<T>,IHandler<T> where T : IVehicle
    {
        private static  T[] garage;
        private static IUI ui;
        private static int counter = 0;
        public void Run()
        {
            garage = new T[5];
            ui = new ConsoleUI();
            do
            {
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
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    ui.PrintString("Invalid Input! Try Again");
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
                    ShowVehicle();
                    break;
                case "2":
                case "0":
                    break;
                default:
                    ui.PrintString("Invalid Input! Try Again");
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
                case "0":
                    MainMenu();
                    break;
                default:
                    ui.PrintString("Invalid Input! Try Again");
                    break;
            }
        }

        private static void ParkCar()
        {
            var (RegistrationNumber, Color, NoOfWheels) = GetCommonFeatures();
            uint NE = ui.AskForUIntInput("Enter Number of Engines");
            var car = new Car(RegistrationNumber, Color, NoOfWheels, VehicleType.Car, NE);
            
            ParkVehicle(car);

            ui.PrintString("Your Car is Successfully Parked");
        }

        private static (string, string, uint) GetCommonFeatures()
        {
            string RegNo = ui.AskForStrInput("Registration Number:");
            string Col = ui.AskForStrInput("Color :");
            uint NofW = ui.AskForUIntInput("Number of Wheels:");
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
            throw new NotImplementedException();
        }

        public T GetByRegistrationNo(int id)
        {
            throw new NotImplementedException();
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
            garage[counter] = item;
            counter++;
        }

        public void PickUpVehicle(T item)
        {
            throw new NotImplementedException();
        }

        T IHandler<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
