using HoLGame.SERVICES;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoLGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuitController : ControllerBase
    {
        private ISuitService suit;

        public SuitController(ISuitService suit)
        {
            this.suit = suit;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(suit.GetAll());
        }







        // GET: api/<SuitController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<SuitController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
