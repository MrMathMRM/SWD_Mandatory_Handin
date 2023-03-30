namespace TroopCoordinator.Simulations
{
    public class TroopCoordinates
    {
        private readonly Random _rnd = new Random();

        // Generate fake MGRS geocoordinates
        // Example: 4Q FJ 12345 67890
        public string GenerateCoordinates()
        {
            return $"{GenerateInt(9)}{GenerateChar()} {GenerateInt(99999)} {GenerateInt(99999)}";
        }

        private char GenerateChar()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int index = _rnd.Next(alphabet.Length);
            return alphabet[index];
        }

        private int GenerateInt(int numberUpTo)
        {
            return _rnd.Next(numberUpTo);
        }
    }
}