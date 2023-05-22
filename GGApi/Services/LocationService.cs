using GGApi.Models.DB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GGApi.Services
{
    public class LocationService
    {
        private readonly IMongoCollection<Location> _locations;

        public LocationService(IOptions<GeoguesserDatabaseSettings> geoguesserDatabaseSettings)
        {
            var mongoClient = new MongoClient(geoguesserDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(geoguesserDatabaseSettings.Value.DatabaseName);
            _locations = mongoDatabase.GetCollection<Location>(geoguesserDatabaseSettings.Value.LocationCollectionName);
        }

        // Get all locations
        public async Task<List<Location>> GetLocationsAsync()
        {
            return await _locations.Find(location => true).ToListAsync();
        }

        // Get a single location
        public async Task<Location> GetLocationAsync(string id)
        {
            return await _locations.Find(location => location.Id == id).FirstOrDefaultAsync();
        }

        // Get a single random location
        public async Task<Location> GetRandomLocationAsync()
        {
            var locations = await _locations.Find(location => true).ToListAsync();
            var random = new Random();
            return locations[random.Next(locations.Count)];
        }

        // Create a location
        public async Task CreateAsync(Location location)
        {
            await _locations.InsertOneAsync(location);
        }

        // Update a location
        public async Task UpdateAsync(string id, Location location)
        {
            await _locations.ReplaceOneAsync(location => location.Id == id, location);
        }
        public async Task UpdateAsync(Location location)
        {
            await _locations.ReplaceOneAsync(s => s.Name == location.Name, location);
        }

        // Delete a location
        public async Task DeleteAsync(string id)
        {
            await _locations.DeleteOneAsync(location => location.Id == id);
        }
    }
}
