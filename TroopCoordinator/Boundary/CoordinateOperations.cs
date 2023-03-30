using TroopCoordinator.Interface;
using TroopCoordinator.Simulations;

namespace TroopCoordinator.Boundary
{
    public class CoordinateOperations : ICoordinates
    {
        private readonly TroopCoordinatesSimulator _coordinate;

        public CoordinateOperations()
        {
            _coordinate = new TroopCoordinatesSimulator();
        }

        public string GetCoordinatesById(string id)
        {
            return _coordinate.GenerateCoordinates();
        }
    }
}
