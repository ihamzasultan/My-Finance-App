using FinanceApp.Models;

namespace FinanceApp.Data.Services
{
    public interface IExpenseServices
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task AddExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int id);
        IQueryable GetPieChartData();
        List<object> GetMonthlyExpenseData();

    }
}
