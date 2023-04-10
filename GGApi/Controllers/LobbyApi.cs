using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using GGApi.Models;

namespace GGApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class LobbyApiController : ControllerBase
    { 
        /// <summary>
        /// Create new lobby
        /// </summary>
        /// <remarks>Create new lobby by providing a username</remarks>
        /// <param name="body">Create lobby for username with null id</param>
        /// <response code="200">Successfully created lobby with id</response>
        [HttpPost]
        [Route("/lobby/new")]
        public virtual IActionResult CreateLobby([FromBody]LobbyDTO body)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Join existing lobby
        /// </summary>
        /// <remarks>Join existing lobby by providing a username and lobby id</remarks>
        /// <param name="body">Join lobby by id</param>
        /// <response code="200">Successfully joined lobby with id or created one if didn&#x27;t exist</response>
        [HttpPost]
        [Route("/lobby/join")]
        public virtual IActionResult JoinLobby([FromBody]LobbyDTO body)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start lobby by id
        /// </summary>
        /// <remarks>Start the lobby with the given id</remarks>
        /// <param name="lobbyId">ID of lobby</param>
        /// <response code="200">Successfully started lobby with id</response>
        [HttpPost]
        [Route("/lobby/{lobby_id}/start")]
        public virtual IActionResult StartLobby([FromRoute][Required]string lobbyId)
        {
            throw new NotImplementedException();
        }
    }
}
