using System.Runtime.CompilerServices;
using Microsoft.Extensions.Caching.Memory;
using TroopCoordinator.Boundary;
using TroopCoordinator.Decorator;
using TroopCoordinator.Interface;
using TroopCoordinator.Simulations;

namespace TroopCoordinator.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiation
            MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
            List<People> people = new();
            CoordinateOperations coordinates = new();
            PrintOperations printer = new();
            // Instantiation - Decorators
            LogPrintsDecorator printerWithLog = new LogPrintsDecorator(printer);
            CoordinateCachingDecorator coordinatesWithCache = new CoordinateCachingDecorator(coordinates, memoryCache);

            // CSV to List
            people = FileOperations.ReadToList("MOCK_DATA.csv");

            while (true)
            {
                Console.Clear();
                foreach (var person in people)
                {
                    printerWithLog.Print($"Name: {person.FirstName} {person.LastName}, Coordinates: {coordinatesWithCache.GetCoordinatesById(person.Id)}");
                }
                Thread.Sleep(5000);
            }

        }
    }
}