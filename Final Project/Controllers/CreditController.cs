using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class CreditController : Controller
    {
        private readonly ICircuitRepository repo;

        public CreditController(ICircuitRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var credit = repo.GetAllCredit();

            return View(credit);
        }

        public IActionResult UpdateCredit(int id)
        {
            Aggregate_Credit cred = repo.GetCredit(id);

            repo.UpdateCredit(cred);

            if (cred == null)
            {
                return View("CreditNotFound");
            }

            return View(cred);
        }

        public IActionResult UpdateCreditToDatabase(Aggregate_Credit aggregate_Credit)
        {
            repo.UpdateCredit(aggregate_Credit);

            return RedirectToAction("ViewCredit", new { id = aggregate_Credit.Tournament_ID });
        }





    }
}