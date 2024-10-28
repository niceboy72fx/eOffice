using eHnue.Server.AppDbContext;
using eHnue.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace eHnue.Server.Repository
{
    public class CountryRepository: IRepository<Country>
    {
        ApplicationDbContext _dbContext;
        public CountryRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Country> CreateAsync(Country _object)
        {
            var obj = await _dbContext.Countries.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        public async Task UpdateAsync(Country _object)
        {
            _dbContext.Countries.Update(_object);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Country>> GetAllAsync()
        {
            return await _dbContext.Countries.ToListAsync();
        }
        public async Task<Country> GetByIdAsync(int Id)
        {
            return await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Countries.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

    }
}
