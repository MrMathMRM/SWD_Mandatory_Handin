using Microsoft.Extensions.Caching.Memory;
using TroopCoordinator.Boundary;
using TroopCoordinator.Interface;

namespace TroopCoordinator.Decorator
{
    /// <summary>
    /// Concrete Decorator
    /// </summary>
    public class CachingCoordinateDecorator : ICoordinates
    {
        private readonly ICoordinates _coordinates;
        private readonly IMemoryCache _cache;
        public CachingCoordinateDecorator(ICoordinates coordinates, IMemoryCache memoryCache)
        {
            _coordinates = coordinates;
            _cache = memoryCache;
        }

        public string GetCoordinatesById(string id)
        {
            string cacheKey = $"Coordinates::{id}";
            if (_cache.TryGetValue<string>(cacheKey, out var cachedCoordinates))
            {
                return cachedCoordinates;
            }
            else
            {
                var currentCoordinates = _coordinates.GetCoordinatesById(id);
                _cache.Set<string>(cacheKey, currentCoordinates, TimeSpan.FromSeconds(15));
                return currentCoordinates;
            }
        }
    }
}
