using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProCircuit.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProCircuit.Controllers
{
    public class CircuitTournamentController : Controller
    {
        private readonly ICircuitRepository repo;

        public CircuitTournamentController(ICircuitRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var tourney = repo.GetAllTournaments();

            return View(tourney);
        }

        public IActionResult ViewCircuitTournaments(int id)
        {
            var tour = repo.GetTournaments(id);

            return View(tour);
        }

            public IActionResult UpdateTournaments(int id)
        {
            CircuitTournaments tour = repo.GetTournaments(id);

            repo.UpdateTournaments(tour);

            if (tour == null)
            {
                return View("TournamentsNotFound");
            }

            return View(tour);
        }

        public IActionResult UpdateTournamentsToDatabase(CircuitTournaments circuittournaments)
        {
            repo.UpdateTournaments(circuittournaments);

            return RedirectToAction("ViewTournaments", new { id = circuittournaments.ID });
        }


        

        








    }
}