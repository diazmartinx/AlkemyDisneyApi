using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlkemyDisneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControlles : ControllerBase
    {
        // GET: api/<AuthControlles>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthControlles>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthControlles>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthControlles>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthControlles>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
