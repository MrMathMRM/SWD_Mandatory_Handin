using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TroopCoordinator.Boundary;
using TroopCoordinator.Interface;

namespace TroopCoordinator.Decorator
{
    /// <summary>
    /// Concrete Decorator
    /// </summary>
    public class LogPrintsDecorator : PrintDecoratorBase
    {
        private Logger _logger = new();

        public LogPrintsDecorator(IPrintOperations  printOperations) : base(printOperations) { }

        public override void Print(string textToPrint)
        {
            _logger.Log(textToPrint);
            base.Print(textToPrint);
        }
    }
}
