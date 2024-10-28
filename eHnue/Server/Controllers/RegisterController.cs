using eHnue.Server.AppDbContext;
using eHnue.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        // GET: api/<RegisterController>
        
        private readonly ApplicationDbContext _context;
        public RegisterController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RegisterController>
        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] Registration registration)
        {
            //return await _countryService.AddCountry(registration);
            _context.Add(registration);
            await _context.SaveChangesAsync();
            return Ok(registration.Id);
        }
        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
