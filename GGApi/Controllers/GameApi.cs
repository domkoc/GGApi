using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using GGApi.Models.DTOs;
using GGApi.Services;

namespace GGApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private readonly GameService _gameService;
        public GameApiController(GameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Poll lobby state
        /// </summary>
        /// <remarks>Poll current state of a lobby by id</remarks>
        /// <param name="lobby_id">ID of lobby</param>
        /// <response code="200">Successfully joined lobby with id or created one if didn&#x27;t exist</response>
        [HttpGet]
        [Route("/game/{lobby_id}")]
        public virtual ActionResult<GameStateDTO> GetGameState([FromRoute][Required]string lobby_id)
        { 
            var state = _gameService.GetGame(lobby_id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state.AsGameStateDto);
        }

        /// <summary>
        /// Poll round tasks
        /// </summary>
        /// <remarks>Poll tasks of current round</remarks>
        /// <param name="lobby_id">ID of lobby</param>
        /// <response code="200">The tasks of the current round and their time limit</response>
        [HttpGet]
        [Route("/game/{lobby_id}/round")]
        public virtual ActionResult<RoundDTO> GetTasks([FromRoute][Required]string lobby_id)
        {
            var state = _gameService.GetGame(lobby_id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state.AsRoundDto);
        }

        /// <summary>
        /// Post answers
        /// </summary>
        /// <remarks>Post the answers of the given round</remarks>
        /// <param name="body">Post answers to tasks</param>
        /// <param name="lobby_id">ID of lobby</param>
        /// <response code="200">Successfully submitted answers</response>
        [HttpPost]
        [Route("/game/{lobby_id}/round")]
        public virtual IActionResult PostTasks([FromBody]AnswersDTO body, [FromRoute][Required]string lobby_id)
        {
            var answers = new List<Lobby.Question>();
            foreach (var answer in body.Answers)
            {
                if (answer.Coordinates.Longitude == null || answer.Coordinates.Lattitude == null) return BadRequest();
                answers.Add(new Lobby.Question(answer.Title, answer.Coordinates.Longitude.Value, answer.Coordinates.Lattitude.Value));
            }
            _gameService.SubmitAnswers(lobby_id, body.Username, answers);
            return Ok();
        }
    }
}
