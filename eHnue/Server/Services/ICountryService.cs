using eHnue.Shared.Models;
using System;

namespace eHnue.Server.Services
{
    public interface ICountryService
    {
        Task<Country> AddCountry(Country country);
        Task<bool> UpdateCountry(int id, Country country);
        Task<bool> DeleteCountry(int id);
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountry(int id);
    }
}
