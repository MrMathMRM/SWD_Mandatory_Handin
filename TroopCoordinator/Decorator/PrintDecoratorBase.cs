using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TroopCoordinator.Interface;

namespace TroopCoordinator.Decorator
{
    /// <summary>
    /// Decorator (as abstract base class)
    /// </summary>
    public abstract class PrintDecoratorBase : IPrintOperations
    {
        private readonly IPrintOperations _printOperations;
        public PrintDecoratorBase(IPrintOperations printOperations)
        {
            _printOperations = printOperations;
        }

        public virtual void Print(string textToPrint)
        {
            _printOperations.Print(textToPrint);
        }
    }
}
