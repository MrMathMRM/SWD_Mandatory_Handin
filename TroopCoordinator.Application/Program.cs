using System.Runtime.CompilerServices;
using TroopCoordinator.Boundary;
using TroopCoordinator.Decorator;
using TroopCoordinator.Simulations;

namespace TroopCoordinator.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiation
            List<People> people = new();
            CoordinateOperations coordinates = new();
            PrintOperations printer = new();
            LogPrintsDecorator printerWithLog = new LogPrintsDecorator(printer);

            // CSV to List
            people = FileOperations.ReadToList("MOCK_DATA.csv");

            while (true)
            {
                Console.Clear();
                foreach (var person in people)
                {
                    printerWithLog.Print($"Name: {person.FirstName} {person.LastName}, Coordinates: {coordinates.GetCoordinatesById(person.Id)}");
                }
                Thread.Sleep(5000);
            }

        }
    }
}