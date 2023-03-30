using System.Collections;

namespace TroopCoordinator.Boundary
{
    public class FileOperations
    {
        public static List<People> ReadToList(string csvFileName)
        {
            var csvLines = File.ReadAllLines(csvFileName);

            var people = new List<People>();

            foreach (var line in csvLines)
            {
                string[] values = line.Replace(" ", "").Split(',');

                string id = values[0];
                string firstName = values[1];
                string lastName = values[2];

                people.Add(new People(id, firstName, lastName));
            }

            return people;
        }
    }
}