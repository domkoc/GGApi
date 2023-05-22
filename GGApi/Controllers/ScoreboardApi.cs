using System;
using Microsoft.AspNetCore.Mvc;
using GGApi.Models.DTOs;

namespace GGApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ScoreboardApiController : ControllerBase
    { 
        /// <summary>
        /// Poll scoreboard
        /// </summary>
        /// <remarks>Poll current state of scoreboard</remarks>
        /// <response code="200">The scores of players currently on the scoreboard</response>
        [HttpGet]
        [Route("/scoreboard")]
        public virtual IActionResult GetScoreboard()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Post score to scoreboard
        /// </summary>
        /// <remarks>Post the users score to the scoreboard</remarks>
        /// <param name="body">Lobby and username of score to post</param>
        /// <response code="200">Successfully submitted score</response>
        [HttpPost]
        [Route("/scoreboard")]
        public virtual IActionResult PostScore([FromBody]NewScoreDTO body)
        {
            throw new NotImplementedException();
        }
    }
}
