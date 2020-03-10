using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProCircuit.Models;

namespace ProCircuit.Controllers
{
    public class ExpensesController : Controller
    {
       
        private readonly IExpensesRepository repo;

        public ExpensesController(IExpensesRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var expenses = repo.GetAllExpenses();

            return View(expenses);
        }

        public IActionResult ViewExpenses(int totalexpenses)
        {
            var expenses = repo.GetExpenses(totalexpenses);

            return View(expenses);
        }

        public IActionResult UpdateExpenses(int totalexpenses)
        {
            Expenses cost = repo.GetExpenses(totalexpenses);

            repo.UpdateExpenses(cost);

            if (cost == null)
            {
                return View("ExpensesNotFound");
            }

            return View(cost);
        }

        public IActionResult UpdateExpensesToDatabase(Expenses expenses)
        {
            repo.UpdateExpenses(expenses);

            return RedirectToAction("ViewExpenses", new { totalexpenses = expenses.TotalExpenses });
        }

        public IActionResult InsertExpenses()
        {
            var cost = repo.AssignAggregateCredit();

            return View(cost);
        }

        public IActionResult InsertExpensesToDatabase(Expenses expensesToInsert)
        {
            repo.InsertExpenses(expensesToInsert);

            return RedirectToAction("Index");
        }







    }
}