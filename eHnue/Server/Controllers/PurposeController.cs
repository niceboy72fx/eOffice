using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using eHnue.Server.Interfaces;
using eHnue.Shared.Models;
using System.Text;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurposeController : ControllerBase
    {
        private readonly IPurpose _IPurpose;
        public PurposeController(IPurpose iPurpose)
        {
            _IPurpose = iPurpose;
        }
        [HttpGet]
        public async Task<List<Purpose>> Get()
        //public async Task<string> Get()
        {              

            return await Task.FromResult(_IPurpose.GetPurposeDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Purpose purpose = _IPurpose.GetPurposeData(id);
            if (purpose != null)
            {
                return Ok(purpose);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Purpose purpose)
        {
            _IPurpose.AddPurpose(purpose);
        }
        [HttpPut]
        public void Put(Purpose purpose)
        {
            _IPurpose.UpdatePurposeDetails(purpose);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IPurpose.DeletePurpose(id);
            return Ok();
        }
    }
}


