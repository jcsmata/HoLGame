using HoLGame.SERVICES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace HoLGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        private readonly IBLGamePlayer blGamePlayer;
        private readonly IBLPlay blPlay;

        public PlayController(IBLGamePlayer blGamePlayer, IBLPlay blPlay)
        {
            this.blGamePlayer = blGamePlayer;
            this.blPlay = blPlay;
        }

        [HttpPost("JoinGame")]
        [Consumes("application/json")]
        public IActionResult JoinGame([FromBody] GamePlayerJoinModel gamePlayer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if(!blGamePlayer.JoinGame(gamePlayer))
                {
                    return BadRequest("Not able to join game.");
                }
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

            return Ok();
                
        }

        [HttpPost("StartGame")]
        [Consumes("application/json")]
        public IActionResult StartGame([FromBody] string gameIdentifier)
        {
            //Validate if game contains all players
            if (!blGamePlayer.ValidateExistingPlayers(gameIdentifier))
                return BadRequest("Still waiting for all players to register!");

            string startMessage = $"Welcome to the game. The players registered for the game are: {blGamePlayer.GetPlayersNameInGame(gameIdentifier)}.";

            blPlay.StartGame(gameIdentifier);

            string descriptionFirstCardInDeck = blPlay.GetDescriptionFirstCardInPlay(gameIdentifier);

            return Ok($"{startMessage}\n{descriptionFirstCardInDeck}");
        }

        [HttpPost("PlayGame")]
        [Consumes("application/json")]
        public IActionResult PlayGame([FromBody] PlayModel play)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Validates if game exists
            if (blGamePlayer.ValidateGame(play.gameIdentifier))
                return BadRequest("Game doesn't exist!");

            blPlay.Play(play);

            return Ok();

        }
    }
}
