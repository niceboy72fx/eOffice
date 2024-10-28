using eHnue.Server.AppDbContext;
using eHnue.Shared.Models;
using eHnue.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproveStateController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ApproveStateController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {


                var devs = await _context.ApproveStates.ToListAsync();
                return Ok(devs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NoContent();
            }

        }
        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reg = await _context.ApproveStates.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(reg);
        }
                

        // POST api/<RegisterController>
        [HttpPost]
        public async Task<IActionResult> Post(ApproveState state)
        {
            //return await _countryService.AddCountry(registration);
            _context.Add(state);
            await _context.SaveChangesAsync();
            return Ok(state.Id);
        }
        
        // PUT api/<RegisterController>/5
        [HttpPut]
        public async Task<bool> Put(ApproveState state)
        {
            _context.Entry(state).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new ApproveState { Id = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
