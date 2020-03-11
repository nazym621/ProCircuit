using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProCircuit.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProCircuit.Controllers
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
            CircuitTournaments cred = repo.GetCredit(id);

            repo.UpdateCredit(cred);

            if (cred == null)
            {
                return View("CreditNotFound");
            }

            return View(cred);
        }

        public IActionResult UpdateCreditToDatabase(CircuitTournaments aggregate_Credit)
        {
            repo.UpdateCredit(aggregate_Credit);

            return RedirectToAction("ViewCredit", new { id = aggregate_Credit.TournamentName });
        }


        public IActionResult InsertCreditToDatabase(CircuitTournaments creditToInsert)
        {
            repo.InsertCredit(creditToInsert);

            return RedirectToAction("Index");
        }

        








    }
}