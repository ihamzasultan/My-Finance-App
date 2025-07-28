using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinanceApp.Models;

namespace FinanceApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Create", "Expense");
    }

    public IActionResult Privacy()
    {
        return RedirectToAction("Index", "Expense");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
