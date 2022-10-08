﻿
using HoLGame.SERVICES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoLGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IBLGame blGame;
        public GameController(IBLGame game)
        {
            this.blGame = game;
        }
        [HttpPost("CreateGame")]
        [Consumes("application/json")]
        public IActionResult CreateGame([FromBody] GameModel game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(blGame.CreateGame(game));
        }
    }
}
