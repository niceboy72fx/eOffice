using eHnue.Server.Services;
using eHnue.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService personService)
        {
            _countryService = personService;
        }
        [HttpGet]
        public async Task<List<Country>> GetAll()
        {
            return await _countryService.GetAllCountries();
        }
        [HttpGet("{id}")]
        public async Task<Country> Get(int id)
        {
            var obj =  await _countryService.GetCountry(id);
            return obj;
        }
        [HttpPost]
        public async Task<Country> AddCountry([FromBody] Country country)
        {
            return await _countryService.AddCountry(country);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCountry(int id)
        {
            await _countryService.DeleteCountry(id);
            return true;
        }
        [HttpPut("{id}")]
        public async Task<bool> UpdateCountry(int id, [FromBody] Country Object)
        {
            await _countryService.UpdateCountry(id, Object);
            return true;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
