namespace FFCG.Garage.ConsoleRunner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Checkout;

    class Program
    {
        private static Dictionary<string, ParkingReceipt> _parkingReceipts;
        private static Garage _garage;

        static void Main()
        {
            _garage = Configure.GarageWithRandomTime();
            _parkingReceipts = new Dictionary<string, ParkingReceipt>();

            while (true)
            {
                PrintUserChoices();

                UserInput input = CaptureUserInput();

                switch (input)
                {
                    case UserInput.ParkCar:
                        ParkCar();
                        break;
                    case UserInput.ExitCar:
                        ExitCar();
                        break;
                    case UserInput.ViewCars:
                        ViewCars();
                        break;
                    case UserInput.Undefined:
                        PrintUndefined();
                        break;
                    case UserInput.ShutDown:
                        ShutDown();
                        break;
                }
            }
        }
        
        private static void ParkCar()
        {
            PrintLine("");
            Print("Enter license number: ");
            string licenseNumber = Console.ReadLine();

            if (string.IsNullOrEmpty(licenseNumber))
            {
                PrintLine("You have to enter a license number!");
                return;
            }

            var car = new Car {LicenseNumber = licenseNumber};
            var parkingReceipt = _garage.ParkCar(car);

            _parkingReceipts.Add(licenseNumber, parkingReceipt);
            PrintLine("Car with license number '{0}' parked in garage at {1}", licenseNumber, parkingReceipt.TimeParked);
            PrintLine("");
        }

        private static void ExitCar()
        {
            PrintLine("");
            Print("Enter license number of car to exit: ");
            string licenseNumber = Console.ReadLine();

            if (string.IsNullOrEmpty(licenseNumber))
            {
                PrintLine("You have to enter a license number!");
                return;
            }

            if (!_parkingReceipts.ContainsKey(licenseNumber))
            {
                PrintLine("No car found with license number '{0}'", licenseNumber);
                return;
            }

            var parkingReceipt = _parkingReceipts[licenseNumber];
            _parkingReceipts.Remove(licenseNumber);

            var invoice = _garage.Checkout(parkingReceipt);

            PrintInvoiceInformation(invoice);
        }

        private static void PrintInvoiceInformation(Invoice invoice)
        {
            PrintLine("");
            PrintLine("You parked {0} hour(s) and {1} minute(s)", invoice.HoursParked, invoice.MinutesParked);
            PrintLine("Price: {0} kr", Math.Round(invoice.TotalAmount, 2));
            PrintLine("");
        }

        private static void ViewCars()
        {
            if (!_garage.ParkedCars.Any())
            {
                PrintLine("No cars parked!");
                return;
            }

            Print("");
            PrintLine("The following cars are parked in the garage:");
            PrintLine("---------------------------------------------");

            foreach (var parkedCar in _garage.ParkedCars)
            {
                PrintLine(parkedCar.LicenseNumber);   
            }
        }

        private static void PrintUndefined()
        {
            PrintLine("Undefined input! Try again!");
        }

        private static void ShutDown()
        {
            PrintLine("Garage is shutting down! Bye bye!");
            Environment.Exit(0);
        }

        private static UserInput CaptureUserInput()
        {
            Print("Enter choice: ");
            var userInput = Console.ReadLine();

            try
            {
                UserInput selectedInput;
                Enum.TryParse(userInput, out selectedInput);

                if(selectedInput == 0)
                    selectedInput = UserInput.Undefined;

                return selectedInput;
            }
            catch (Exception)
            {
                return UserInput.Undefined;
            }
            
        }

        private static void PrintUserChoices()
        {
            PrintLine("");
            PrintLine("Press: 1 to park a car");
            PrintLine("Press: 2 to exit a car");
            PrintLine("Press: 3 to view parked cars");
            PrintLine("Press: 4 to shut down");
            PrintLine("");
        }

        private static void PrintLine(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }

        private static void Print(string message, params object[] parameters)
        {
            Console.Write(message, parameters);
        }
    }
}
