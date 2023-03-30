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
        private static string directory = @".\logs\";
        private static string fileName = "log.txt";

        public void Log(string text)
        {
            if (!CheckForExistingDirectory(directory))
            {
                CreateDirectory(directory);
            }

            SaveLogToFile(directory, fileName, PrepareLogForPersistence(DateTime.Now, text));
        }

        public bool CheckForExistingDirectory(string path)
        {
            bool existingDirectoryFound = Directory.Exists(path);
            return existingDirectoryFound;
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public bool CheckForExistingFile(string path, string fileName)
        {
            bool existingFileFound = File.Exists(@$"{path}\{fileName}");

            if (!existingFileFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found!");
                Console.ResetColor();
            }

            return existingFileFound;
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
