using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TroopCoordinator.Interface;

namespace TroopCoordinator.Boundary
{
    public class Logger : ILogger
    {
        private const string Directory = @".\logs\";
        private const string FileName = "log.txt";

        public void Log(string text)
        {
            if (!CheckForExistingDirectory(Directory))
            {
                CreateDirectory(Directory);
            }

            SaveLogToFile(Directory, FileName, PrepareLogForPersistence(DateTime.Now, text));
        }

        public bool CheckForExistingDirectory(string path)
        {
            bool existingDirectoryFound = System.IO.Directory.Exists(path);
            return existingDirectoryFound;
        }

        public void CreateDirectory(string path)
        {
            System.IO.Directory.CreateDirectory(path);
        }

        public string PrepareLogForPersistence(DateTimeOffset date, string text)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Date: {date.ToString("yyyy/dd/MM HH:mm").Replace("-", "/")}, ");
            sb.Append($"{text}; ");
            sb.AppendLine();
            return sb.ToString();
        }

        public void SaveLogToFile(string path, string fileName, string logToPersist)
        {
            string filePath = @$"{path}{fileName}";
            File.AppendAllText(filePath, logToPersist);
        }
    }
}
