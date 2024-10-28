using eHnue.Server.AppDbContext;
using eHnue.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproveLogController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public ApproveLogController(ApplicationDbContext context)
        {
            this._context = context;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var devs = await _context.ApproveLogs.ToListAsync();
                return Ok(devs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NoContent();
            }

        }

        [HttpGet("GetLogByStaffId/{staffId}")]
        public async Task<IActionResult> GetLogByStaffId(int staffId)
        {
            try
            {
                var list =  await _context.ApproveLogs.Where(m => m.ApproveStaffId == staffId).ToListAsync();
                return Ok(list);
            }
            catch
            {
                return NoContent();
                //throw;
            }
        }

        // POST api/<RegisterController>
        [HttpPost("SaveApproveLog")]
        public async Task<IActionResult> SaveApproveLog(ApproveLog log)
        {
            _context.Add(log);
            await _context.SaveChangesAsync();
            return Ok(log.Id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new ApproveLog { Id = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
