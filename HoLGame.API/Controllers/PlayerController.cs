using HoLGame.SERVICES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoLGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IBLPlayer blPlayer;

        public PlayerController(IBLPlayer blPlayer)
        {
            this.blPlayer = blPlayer;
        }

        [HttpPost("CreatePlayer")]
        [Consumes("application/json")]
        public IActionResult CreatePlayer([FromBody] PlayerModel player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string output = String.Empty;

            //TODO: Validate duplicate names

            try
            {
                output = blPlayer.CreatePlayer(player);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

            return Ok(output);
        }
    }
}
