using System;
using Microsoft.AspNetCore.Mvc;
using GGApi.Models.DTOs;
using GGApi.Services;

namespace GGApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ScoreboardApiController : ControllerBase
    { 
        private readonly ScoreboardService _scoreboardService;

        public ScoreboardApiController(ScoreboardService scoreboardService)
        {
            _scoreboardService = scoreboardService;
        }

        /// <summary>
        /// Poll scoreboard
        /// </summary>
        /// <remarks>Poll current state of scoreboard</remarks>
        /// <response code="200">The scores of players currently on the scoreboard</response>
        [HttpGet]
        [Route("/scoreboard")]
        public async Task<ScoreboardDTO> GetScoreboard()
        {
            var scores = await _scoreboardService.GetScoreboardAsync();
            var scoreboardDTO = new ScoreboardDTO();
            foreach (var score in scores)
            {
                var player = new ScoreboardDTOPlayers()
                { 
                    Username = score.Username, 
                    Score = score.Score
                };
                scoreboardDTO.Players.Add(player);
            }
            return scoreboardDTO;
        }

        /// <summary>
        /// Post score to scoreboard
        /// </summary>
        /// <remarks>Post the users score to the scoreboard</remarks>
        /// <param name="body">Lobby and username of score to post</param>
        /// <response code="200">Successfully submitted score</response>
        [HttpPost]
        [Route("/scoreboard")]
        public async virtual Task<IActionResult> PostScore([FromBody]NewScoreDTO body)
        {
            await _scoreboardService.CreateAsync(body.LobbyId, body.Username);
            return Ok();
        }
    }
}
