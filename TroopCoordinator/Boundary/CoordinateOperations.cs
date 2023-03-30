using TroopCoordinator.Interface;
using TroopCoordinator.Simulations;

namespace TroopCoordinator.Boundary
{
    public class CoordinateOperations : ICoordinates
    {
        private readonly TroopCoordinates _coordinate;

        public CoordinateOperations()
        {
            _coordinate = new TroopCoordinates();
        }

        public string GetCoordinatesById(string id)
        {
            return _coordinate.GenerateCoordinates();
        }
    }
}
