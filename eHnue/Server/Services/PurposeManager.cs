using eHnue.Server.AppDbContext;
using eHnue.Server.Interfaces;
using eHnue.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace eHnue.Server.Services
{
    public class PurposeManager : IPurpose
    {
        private readonly ApplicationDbContext _dbContext = new();
        public PurposeManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all Purpose details
        public List<Purpose> GetPurposeDetails()
        {
            try
            {
                return _dbContext.Purposes.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new purpose record
        public void AddPurpose(Purpose purpose)
        {
            try
            {
                _dbContext.Purposes.Add(purpose);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public void UpdatePurposeDetails(Purpose purpose)
        {
            try
            {
                _dbContext.Entry(purpose).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular user
        public Purpose GetPurposeData(int id)
        {
            try
            {
                Purpose? purpose = _dbContext.Purposes.Find(id);
                if (purpose != null)
                {
                    return purpose;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeletePurpose(int id)
        {
            try
            {
                Purpose? purpose = _dbContext.Purposes.Find(id);
                if (purpose != null)
                {
                    _dbContext.Purposes.Remove(purpose);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
