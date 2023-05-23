using GGApi.Models.DB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GGApi.Services
{
    public class ScoreboardService
    {
        private readonly IMongoCollection<Scoreboard> _scoreboard;
        private readonly GameService _gameService;

        public ScoreboardService(IOptions<GeoguesserDatabaseSettings> geoguesserDatabaseSettings, GameService gameService)
        {
            var mongoClient = new MongoClient(geoguesserDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(geoguesserDatabaseSettings.Value.DatabaseName);
            _scoreboard = mongoDatabase.GetCollection<Scoreboard>(geoguesserDatabaseSettings.Value.ScoreboardCollectionName);
            _gameService = gameService;
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

        // Create a score from a game
        public async Task CreateAsync(string lobbyId, string username)
        {
            var lobby = _gameService.GetGame(lobbyId);
            if (lobby == null)
            {
                return;
            }
            var player = lobby.Players.Find(x => x.Username == username);
            if (player == null)
            {
                return;
            }
            await _scoreboard.InsertOneAsync(new Scoreboard()
            {
                Username = username,
                Score = player.Score
            });
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
