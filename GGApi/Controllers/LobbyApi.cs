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
    public class LobbyApiController : ControllerBase
    { 
        private readonly GameService _gameService;
        public LobbyApiController(GameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Create new lobby
        /// </summary>
        /// <remarks>Create new lobby by providing a username</remarks>
        /// <param name="body">Create lobby for username with null id</param>
        /// <response code="200">Successfully created lobby with id</response>
        [HttpPost]
        [Route("/lobby/new")]
        public virtual ActionResult<LobbyDTO> CreateLobby([FromBody]LobbyDTO body)
        {
            _gameService.CreateGame(body.Username, body.LobbyId);
            return body;
        }

        /// <summary>
        /// Join existing lobby
        /// </summary>
        /// <remarks>Join existing lobby by providing a username and lobby id</remarks>
        /// <param name="body">Join lobby by id</param>
        /// <response code="200">Successfully joined lobby with id or created one if didn&#x27;t exist</response>
        [HttpPost]
        [Route("/lobby/join")]
        public virtual ActionResult<LobbyDTO> JoinLobby([FromBody]LobbyDTO body)
        {
            if (_gameService.JoinGame(body.Username, body.LobbyId))
            {
                return body;
            }
            return BadRequest();
        }

        /// <summary>
        /// Start lobby by id
        /// </summary>
        /// <remarks>Start the lobby with the given id</remarks>
        /// <param name="lobby_id">ID of lobby</param>
        /// <response code="200">Successfully started lobby with id</response>
        [HttpPost]
        [Route("/lobby/{lobby_id}/start")]
        public virtual ActionResult<GameStateDTO> StartLobby([FromRoute][Required]string lobby_id)
        {
            var lobby = _gameService.StartGame(lobby_id);
            if (lobby == null)
            {
                return BadRequest();
            }
            return Ok(lobby.AsGameStateDto);
        }
    }
}
