using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Services
{
    public class ExpenseServices : IExpenseServices
    {
        private readonly FinanceAppContext _context;
        public ExpenseServices(FinanceAppContext context)
        {
            _context = context;
        }
        public async Task AddExpenseAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public Task DeleteExpenseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            var expenses = await _context.Expenses.ToListAsync(); ;
            return expenses;
        }

        public List<object> GetMonthlyExpenseData()
        {
            var monthlyData = _context.Expenses
                .GroupBy(e => new { e.Date.Year, e.Date.Month })
                .AsEnumerable()
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month) // ✅ Sort BEFORE projecting
                .Select(g => new
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMM yyyy"),
                    Total = g.Sum(e => e.Amount)
                })
                .ToList<object>();

            return monthlyData;
        }


        public IQueryable GetPieChartData()
        {
            var chartData = _context.Expenses
                .GroupBy(e => e.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    TotalAmount = g.Sum(e => e.Amount)
                });
            return chartData;
        }

        public Task UpdateExpenseAsync(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
     