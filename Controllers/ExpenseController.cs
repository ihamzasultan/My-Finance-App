using FinanceApp.Data;
using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpenseController : Controller
    {
        // Controller actions go here
        public readonly IExpenseServices _expenseServices;
        public ExpenseController(IExpenseServices expenseServices)
        {
            _expenseServices = expenseServices;
        }

        public async Task<IActionResult> Index()
        {
            // Logic to retrieve and display expenses
            var expenses = await _expenseServices.GetAllExpensesAsync();
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
                await _expenseServices.AddExpenseAsync(expense);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult getPieChart()
        {
            var chartData = _expenseServices.GetPieChartData();
            System.Console.WriteLine("Pie Chart Data: " + Json(chartData));
            return Json(chartData);
        }

        [HttpGet]
        public IActionResult getMonthlyChart()
        {
            var monthlyData = _expenseServices.GetMonthlyExpenseData();
            System.Console.WriteLine("Monthly Data: " + Json(monthlyData));
            return Json(monthlyData);
        }
    }
}