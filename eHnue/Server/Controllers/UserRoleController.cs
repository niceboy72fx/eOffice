using eHnue.Server.AppDbContext;
using eHnue.Shared;
using eHnue.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System;
using eHnue.Shared;
using System.Runtime.InteropServices;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserRoleController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var devs = await _context.UserRoles.ToListAsync();
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
            var reg = await _context.UserRoles.FirstOrDefaultAsync(a => a.Id == id);
            GiangVien_DetailAPI gv = await CommonConstant.GetStaffInfo(reg.StaffId);
            UserRoleView item = new UserRoleView();
            item.Id = reg.Id;
            item.StaffId = reg.StaffId;
            item.RoleName = reg.RoleName;
            item.StaffName = reg.StaffName;
            item.DeptId = gv.DepartmentId.ToString();
            return Ok(item);
        }

        // POST api/<RegisterController>
        [HttpPost]

        public async Task<IActionResult> Post(UserRole assign)
        {
            //return await _countryService.AddCountry(registration);
            _context.Add(assign);
            await _context.SaveChangesAsync();
            return Ok(assign.Id);
        }
        // PUT api/<RegisterController>/5
        [HttpPut]
        public async Task<IActionResult> Put(UserRole assign)
        {
            _context.Entry(assign).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(assign.Id);
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new UserRole { Id = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
