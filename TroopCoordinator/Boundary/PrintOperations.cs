using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TroopCoordinator.Interface;

namespace TroopCoordinator.Boundary
{
    public class PrintOperations : IPrintOperations
    {

        /// <summary>
        /// Concrete Component
        /// </summary>
        public void Print(string textToPrint)
        {
            string date = DateTime.Now.ToString();

            Console.Title = $"Troop Coordinator - Updated: {date}";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Timestamp: {date}, {textToPrint}");
            Console.ResetColor();
        }
    }
}
