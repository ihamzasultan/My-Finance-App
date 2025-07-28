using FinanceApp.Data;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpenseController : Controller
    {
        // Controller actions go here
        private readonly FinanceAppContext _context;
        public ExpenseController(FinanceAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Logic to retrieve and display expenses
            var expenses = await _context.Expenses.ToListAsync();
            return View(expenses);
        }

        public IActionResult Create()
        {
            // Logic to display the create expense form
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            // Logic to display the create expense form

            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}