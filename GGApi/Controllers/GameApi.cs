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
    public class GameApiController : ControllerBase
    { 
        /// <summary>
        /// Poll lobby state
        /// </summary>
        /// <remarks>Poll current state of a lobby by id</remarks>
        /// <param name="lobbyId">ID of lobby</param>
        /// <response code="200">Successfully joined lobby with id or created one if didn&#x27;t exist</response>
        [HttpGet]
        [Route("/game/{lobby_id}")]
        public virtual IActionResult GetGameState([FromRoute][Required]string lobbyId)
        { 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Poll round tasks
        /// </summary>
        /// <remarks>Poll tasks of current round</remarks>
        /// <param name="lobbyId">ID of lobby</param>
        /// <response code="200">The tasks of the current round and their time limit</response>
        [HttpGet]
        [Route("/game/{lobby_id}/round")]
        public virtual IActionResult GetTasks([FromRoute][Required]string lobbyId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Post answers
        /// </summary>
        /// <remarks>Post the answers of the given round</remarks>
        /// <param name="body">Post answers to tasks</param>
        /// <param name="lobbyId">ID of lobby</param>
        /// <response code="200">Successfully submitted answers</response>
        [HttpPost]
        [Route("/game/{lobby_id}/round")]
        public virtual IActionResult PostTasks([FromBody]AnswersDTO body, [FromRoute][Required]string lobbyId)
        {
            throw new NotImplementedException();
        }
    }
}
