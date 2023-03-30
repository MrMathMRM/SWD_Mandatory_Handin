using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroopCoordinator.Interface
{
    public interface ILogger
    {
        void Log(string text);

        bool CheckForExistingDirectory(string path);
        void CreateDirectory(string path);
        bool CheckForExistingFile(string path, string fileName);
        string PrepareLogForPersistence(DateTimeOffset date, string text);
        void SaveLogToFile(string path, string fileName, string logToPersist);
    }
}
