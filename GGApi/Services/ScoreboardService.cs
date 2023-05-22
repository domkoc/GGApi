using GGApi.Models.DB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GGApi.Services
{
    public class ScoreboardService
    {
        private readonly IMongoCollection<Scoreboard> _scoreboard;

        public ScoreboardService(IOptions<GeoguesserDatabaseSettings> geoguesserDatabaseSettings)
        {
            var mongoClient = new MongoClient(geoguesserDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(geoguesserDatabaseSettings.Value.DatabaseName);
            _scoreboard = mongoDatabase.GetCollection<Scoreboard>(geoguesserDatabaseSettings.Value.ScoreboardCollectionName);
        }

        // Get all scores
        public async Task<List<Scoreboard>> GetScoreboardAsync()
        {
            return await _scoreboard.Find(scoreboard => true).ToListAsync();
        }

        // Get a single score
        public async Task<Scoreboard> GetScoreboardAsync(string id)
        {
            return await _scoreboard.Find(scoreboard => scoreboard.Id == id).FirstOrDefaultAsync();
        }

        // Create a score
        public async Task CreateAsync(Scoreboard scoreboard)
        {
            await _scoreboard.InsertOneAsync(scoreboard);
        }

        // Update a score
        public async Task UpdateAsync(string id, Scoreboard scoreboard)
        {
            await _scoreboard.ReplaceOneAsync(scoreboard => scoreboard.Id == id, scoreboard);
        }
        public async Task UpdateAsync(Scoreboard scoreboard)
        {
            await _scoreboard.ReplaceOneAsync(s => s.Username == scoreboard.Username, scoreboard);
        }

        // Delete a score
        public async Task DeleteAsync(string id)
        {
            await _scoreboard.DeleteOneAsync(scoreboard => scoreboard.Id == id);
        }
    }
}
