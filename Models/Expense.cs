
// File: FinanceApp/Models/Expense.cs
//Model Class for Expense
using System;
using System.ComponentModel.DataAnnotations;
namespace FinanceApp.Models
{
public class Expense
{
    // we need to add properties for the Expense class (a table what an Expense is)
    public int Id { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

}    
}
