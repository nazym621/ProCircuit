using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProCircuit.Models;

namespace ProCircuit.Controllers
{
    public class TournamentController : Controller
    {
        
        private readonly ITournamentRepository repo;

        public TournamentController(ITournamentRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var tourney = repo.GetAllTournaments();

            return View(tourney);
        }

        public IActionResult ViewTournament(string name)
        {
            var tourney = repo.GetTournament(name);

            return View(tourney);
        }

        public IActionResult UpdateTournament(string name)
        {
            Tournament tourney = repo.GetTournament(name);

            repo.UpdateTournament(tourney);

            if (tourney == null)
            {
                return View("TournamentNotFound");
            }

            return View(tourney);
        }

        public IActionResult UpdateTournamentToDatabase(Tournament tournament)
        {
            repo.UpdateTournament(tournament);

            return RedirectToAction("ViewTournament", new { name = tournament.Name });
        }

        public IActionResult InsertTournament()
        {
            var tourney = repo.AssignAggregateCredit();

            return View(tourney);
        }

        public IActionResult InsertTournamentToDatabase(Tournament tournamentToInsert)
        {
            repo.InsertTournament(tournamentToInsert);

            return RedirectToAction("Index");
        }






    }
}