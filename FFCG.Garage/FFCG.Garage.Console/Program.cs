namespace FFCG.Garage.ConsoleRunner
{
    using System;

    class Program
    {
        private static Garage _garage;

        static void Main(string[] args)
        {
            _garage = new Garage();

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
                }

                if (input == UserInput.ShutDown)
                    break;
            }

        }

        private static void PrintUndefined()
        {
            throw new NotImplementedException();
        }

        private static void ShutDown()
        {
            throw new NotImplementedException();
        }

        private static void ViewCars()
        {
            throw new NotImplementedException();
        }

        private static void ExitCar()
        {
            throw new NotImplementedException();
        }

        private static void ParkCar()
        {
            throw new NotImplementedException();
        }

        private static UserInput CaptureUserInput()
        {
            Console.Write("Enter choice: ");
            var userInput = Console.ReadLine();

            try
            {
                UserInput selectedInput;
                Enum.TryParse(userInput, out selectedInput);

                return selectedInput;
            }
            catch (Exception)
            {
                return UserInput.Undefined;
            }
            
        }

        private static void PrintUserChoices()
        {
            Console.WriteLine("Press: 1 to park a car");
            Console.WriteLine("Press: 2 to exit a car");
            Console.WriteLine("Press: 3 to view parked cars");
            Console.WriteLine("Press: 4 to shut down");
        }
    }

    public enum UserInput
    {
        ParkCar = 1,
        ExitCar = 2,
        ViewCars = 3,
        ShutDown = 4,
        Undefined
    }
}
