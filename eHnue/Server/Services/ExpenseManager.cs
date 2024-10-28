using eHnue.Shared.Models;
using eHnue.Server.Interfaces;

using Microsoft.EntityFrameworkCore;
using eHnue.Server.AppDbContext;

namespace eHnue.Server.Services
{
    public class ExpenseManager: IExpense
    {
        readonly ApplicationDbContext _dbContext = new();
        public ExpenseManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all expense details
        public List<Expense> GetExpenseDetails()
        {
            try
            {
                return _dbContext.Expenses.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new expense record
        public void AddExpense(Expense expense)
        {
            try
            {
                _dbContext.Expenses.Add(expense);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar expense
        public void UpdateExpenseDetails(Expense expense)
        {
            try
            {
                _dbContext.Entry(expense).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular expense
        public Expense GetExpenseData(int id)
        {
            try
            {
                Expense? expense = _dbContext.Expenses.Find(id);
                if (expense != null)
                {
                    return expense;
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
        //To Delete the record of a particular expense
        public void DeleteExpense(int id)
        {
            try
            {
                Expense? expense = _dbContext.Expenses.Find(id);
                if (expense != null)
                {
                    _dbContext.Expenses.Remove(expense);
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

