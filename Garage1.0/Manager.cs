using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Garage1._0
{
   public class Manager 
    {
        private static Garage<IVehicle> garage;
        private static IUI ui;
        public  static int capacity;
        public void Run()
        {
            garage = new Garage<IVehicle>(10);
            
            capacity = 10;
            ui = new ConsoleUI();
            do
            {
                Console.Clear();
                MainMenu();
                Input();
            } while (true);
        }

        private static void MainMenu()
        {
            ui.PrintString("1.Install a New Garage");
            ui.PrintString("2.Manage Vehicle");
            ui.PrintString("3.Search Vehicle");
            ui.PrintString("4.View the Garage Structure");
            ui.PrintString("5.Resize the Existing Garage");
            ui.PrintString("6.Seed Garage with Sample Data");
            ui.PrintString("0.Exit");
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
                case "4":
                    ViewGarage();
                    break;
                case "5":
                    ResizeGarage();
                    break;
                case "6":
                    SeedGarageWithSampleData();
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

        private static void ResizeGarage() 
        {
            ui.PrintString($"Current capacity of the Garage is {capacity} if you reduce the size you may loose data");
            int size = ui.AskForIntInput("Enter the New Size for the Garage ");
            if (size < 1)
                throw new ArgumentOutOfRangeException("invalid size");
            garage.resize(size);
            ui.PrintString("Garage is Resized Successfully");
            ui.Rkey();
        }

        private static void ViewGarage()
        {
            ui.PrintString("Garage");
            var VA = garage.GetAll();
            int RecordCount = 0;
            foreach (var obj in VA)
            {
                if (obj != null)
                    ui.PrintString($"{++RecordCount} Occupied");
            }
            foreach (var obj in VA)
            {
                if (obj == null)
                    ui.PrintString($"{++RecordCount} Free Space");
            }
            ui.Rkey();
        }

        private static void InstallGarage()
        {
            string conform=ui.AskForStrInput("You will loose all the data and Do you want to proceed ?y/n");
            if (conform.ToUpper() == "Y")
            {
               
                int size = ui.AskForIntInputWithLimit($"Enter the Size of Garage to Install 1 to 200", 1, 200);
                garage = new Garage<IVehicle>(size);
                capacity = size;
                ui.PrintString($"Garage of size {size} Installed Successfully");
                ui.Rkey();
            }
            else
            {
                ui.PrintString("Your Current request was Cancelled");
                ui.Rkey();
            }
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
                    AddVehicle();
                    break;
                case "2":
                    PickupVehicle();
                    break;
                case "0":
                    break;
                default:
                    ui.PrintString("Invalid Input! Press Enter to Try Again");
                    ui.Rkey();
                    break;
            }
        }

        private static void PickupVehicle()
        {
            string reg = ui.AskForStrInput("Registration Number to CheckOut");
            bool status = garage.Unpark(reg);
            string x=(status == true)? "Successfully Check Out! Have a Nice Day" : "Invalid Input Unable to CheckOut! Try Again..";
            ui.PrintString(x);
            ui.Rkey();
        }

        private static void AddVehicle()
        {
            int count = 0;
            for (int i = 0; i < garage.Count() ; i++)
            {
                if (garage[i] != null)
                    count++;
            }
            if (count < capacity)
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
                        AddCar();
                        break;
                    case "2":
                        AddBus();
                        break;
                    case "3":
                        AddBoat();
                        break;
                    case "4":
                        AddMotorcycle();
                        break;
                    case "5":
                        AddAirplane();
                        break;
                    case "0":
                        break;
                    default:
                        ui.PrintString("Invalid Input! Press Enter to Try Again");
                        ui.Rkey();
                        break;
                }
            }
            else
                ui.PrintString("Garage is Full");
                ui.Rkey();
        }
        private static void AddCar()
        {
            (string RegistrationNumber, string Color, int NoOfWheels) = GetCommonFeatures();
            int NE = ui.AskForIntInput("Enter Number of Engines");
            Car car = new Car(RegistrationNumber, Color, NoOfWheels, VehicleType.Car, NE);
            bool status=garage.Park(car);
            if (status == true)
                ui.PrintString("Your Car is Successfully Parked");
            else
                ui.PrintString("Failed Check your Registration Number");
        }

        private static void SearchMenu()
        {
            ui.PrintString("1. View All Parked Vehicle");
            ui.PrintString("2. View All Vehicles by Type");
            ui.PrintString("3. View by Registration Number");
            ui.PrintString("4. View by Color");
            ui.PrintString("5. View by No of Wheels");
            ui.PrintString("6. List and Count by Vehicle Type");
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
                    ViewByType();
                    break;
                case "3":
                    ViewByReg();
                    break;
                case "4":
                    ViewByColor();
                    break;
                case "5":
                    ViewByWheels();
                    break;
                case "6":
                    ListandCountByType();
                    break;
                case "0":
                    break;
                default:
                    ui.PrintString("Invalid Input! Press Enter to Try Again");
                    ui.Rkey();
                    break;
            }

        }

        private static void ListandCountByType()
        {
            var VA = garage.GetAll().ToList();
            var result = VA
                .Where(x => x?.RegistrationNumber != null)
                .GroupBy(v => v?.Type);
                
            foreach (var i in result)
            {
                ui.PrintString($"{i.Key} : {i.Count()} ");
                foreach (var x in i)
                    if (x != null)
                        ui.PrintString(x?.ToString());
            }
            ui.Rkey();
        }


        private static void ViewByWheels()
        {
            int wh = ui.AskForIntInput("Enter Number of Wheels for the Vehicle");
            var obj = garage.GetByWheels(wh);
            if(obj.Count!=0)
            { 
                foreach (var i in obj)
                    ui.PrintString(i.ToString());
                ui.Rkey();
            }
            else
            {
                ui.PrintString("No such Vehicle Found");
                ui.Rkey();
            }
        }

        private static void ViewByColor()
        {
            string col = ui.AskForStrInput("Enter the Color of the Vehicle");
            var obj = garage.GetByColor(col);
            if (obj.Count == 0)
            { 
                ui.PrintString("No such Vehicle Found");
                ui.Rkey();
            }
            else
            { 
                foreach (var i in obj)
                    ui.PrintString(i.ToString());
                ui.Rkey();
            }
        }

        private static void ViewByType()
        {
            foreach (var VT in Enum.GetValues(typeof(VehicleType)))
                ui.PrintString($"{(int)VT} - {VT}");
            int Vtype = ui.AskForIntInputWithLimit("Enter a Valid Number", 1, 4);
            var obj=garage.GetByType((VehicleType)Vtype);
            if(obj.Count==0)
            {
                 ui.PrintString("No such Vehicle Found");
                 ui.Rkey();
            }
            else
            { 
                foreach (var i in obj)
                    ui.PrintString(i.ToString());
                ui.Rkey();
            }
        }
        private static void ViewByReg()
        {
            string reg = ui.AskForStrInput("Enter Registration Number to List Vehicle");
            var obj=garage.GetByRegistrationNo(reg);
            
            if (obj.Count==0)
            {
                ui.PrintString("No such Vehicle Found");
                ui.Rkey();
            }
            else
            {
                foreach(var i in obj)
                ui.PrintString(i.ToString());
                ui.Rkey();
            }
                
        }

        private static void ViewAll()
        {
            ui.PrintString("Parked vehicles are");
            var VA = garage.GetAll();
            foreach (var obj in VA)
            {
                if (obj!=null)
                    ui.PrintString(obj.ToString());
            }
            ui.Rkey();
        }
        private static void AddAirplane()
        {
            (string RegistrationNumber, string Color, int NoOfWheels) = GetCommonFeatures();
            int NS = ui.AskForIntInput("Enter Number of Seats");
            Airplane airplane = new Airplane(RegistrationNumber, Color, NoOfWheels, VehicleType.Airplane, NS);
            bool status=garage.Park(airplane);
            if (status == true)
                ui.PrintString("Your Airplane is Successfully Parked");
            else
                ui.PrintString("Failed Check your Registration Number");
        }

        private static void AddMotorcycle()
        {
            (string RegistrationNumber, string Color, int NoOfWheels) = GetCommonFeatures();
            string CV = ui.AskForStrInput("Enter the Cylinder Volume");
            Motorcycle motorcycle = new Motorcycle(RegistrationNumber, Color, NoOfWheels, VehicleType.Motorcycle, CV);
            bool status=garage.Park(motorcycle);
            
            if (status == true)
                ui.PrintString("Your Motorcycle is Successfully Parked");
            else
                ui.PrintString("Failed Check your Registration Number");
        }

        private static void AddBoat()
        {
            (string RegistrationNumber, string Color, int NoOfWheels) = GetCommonFeatures();
            int len = ui.AskForIntInput("Enter the Length of the Boat");
            Boat boat = new Boat (RegistrationNumber, Color, NoOfWheels, VehicleType.Boat, len);
            bool status=garage.Park(boat);
            
            if (status == true)
                ui.PrintString("Your Boat is Successfully Parked");
            else
                ui.PrintString("Failed Check your Registration Number");
        }

        private static void AddBus()
        {
            (string RegistrationNumber, string Color, int NoOfWheels) = GetCommonFeatures();
            ui.PrintString("Enter Fuel Type");
            foreach (var FT in Enum.GetValues(typeof(FuelType)))
                ui.PrintString($"{(int)FT} - {FT}");
            int Ftype = ui.AskForIntInputWithLimit ("Enter a Valid Number",1,2);
            Bus bus = new Bus(RegistrationNumber, Color, NoOfWheels, VehicleType.Bus, (FuelType)Ftype);
            bool status=garage.Park(bus);
            if (status == true)
                ui.PrintString("Your Bus is Successfully Parked");
            else
                ui.PrintString("Failed Check your Registration Number");
            
        }
        private static (string, string, int) GetCommonFeatures()
        {
            string RegNo = ui.AskForStrInput("Registration Number ");
            string Col = ui.AskForStrInput("Color ");
            int NofW = ui.AskForIntInput("Number of Wheels ");
            return (RegNo, Col, NofW);
        }

        private static void SeedGarageWithSampleData()
        {
            garage.Park(new Car("ABC123", "Silver", 4, VehicleType.Car, 2));
            garage.Park(new Car("bcd234", "Red", 4, VehicleType.Car, 1));
            garage.Park(new Bus("Tyg123456", "Blue", 8, VehicleType.Bus, FuelType.Diesel));
            garage.Park(new Bus("FRG345678", "Green", 6, VehicleType.Bus, FuelType.Gasoline));
            garage.Park(new Boat("SL456", "White", 0, VehicleType.Boat, 100));
            garage.Park(new Motorcycle("th321", "yellow", 2, VehicleType.Motorcycle,"150cc"));
            garage.Park(new Airplane("AI360", "yellow", 10, VehicleType.Airplane, 200));
            ui.PrintString("Garage is Seeded with Sample Data");
            ui.Rkey();
        }

    }
}
