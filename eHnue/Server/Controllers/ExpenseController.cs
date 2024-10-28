using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eHnue.Shared.Models;
using eHnue.Server.Interfaces;
using System.Collections.Generic;

namespace eHnue.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpense _IExpense;
        public ExpenseController(IExpense iExpense)
        {
            _IExpense = iExpense;
        }
        [HttpGet]
        public async Task<List<Expense>> Get()
        {
            return await Task.FromResult(_IExpense.GetExpenseDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Expense expense = _IExpense.GetExpenseData(id);
            if (expense != null)
            {
                return Ok(expense);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Expense expense)
        {
            _IExpense.AddExpense(expense);
        }
        [HttpPut]
        public void Put(Expense expense)
        {
            _IExpense.UpdateExpenseDetails(expense);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IExpense.DeleteExpense(id);
            return Ok();
        }
    }
}
