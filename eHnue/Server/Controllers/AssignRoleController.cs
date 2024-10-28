using eHnue.Server.AppDbContext;
using eHnue.Server.Services;
using eHnue.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignRoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AssignRoleController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            try
            {
                var devs = await _context.AssignRoles.ToListAsync();
                return Ok(devs);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return Ok(null);
        }
        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reg = await _context.AssignRoles.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(reg);
        }

        // POST api/<RegisterController>
        [HttpPost]

        public async Task<IActionResult> Post(AssignRole assign)
        {
            //return await _countryService.AddCountry(registration);
            _context.Add(assign);
            await _context.SaveChangesAsync();
            return Ok(assign.Id);
        }
        // PUT api/<RegisterController>/5
        [HttpPut]
        public async Task<IActionResult> Put(AssignRole assign)
        {
            _context.Entry(assign).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new AssignRole { Id = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
