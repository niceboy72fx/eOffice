using eHnue.Shared.Models;
namespace eHnue.Server.Interfaces
{
    public interface IExpense
    {
        public List<Expense> GetExpenseDetails();
        public void AddExpense(Expense expense);
        public void UpdateExpenseDetails(Expense expense);
        public Expense GetExpenseData(int id);
        public void DeleteExpense(int id);
    }
}
