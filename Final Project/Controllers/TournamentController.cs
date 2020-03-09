using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace ProCircuit.Controllers
{
    public class TournamentController : Controller
    {
        
        private readonly ITournamentRepository repo;

        public TournamentController(ITournamentRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var tourney = repo.GetAllTournaments();

            return View(tourney);
        }

        public IActionResult ViewTournament(string type)
        {
            var tourney = repo.GetTournament(type);

            return View(tourney);
        }

        public IActionResult UpdateTournament(string type)
        {
            Tournament tourney = repo.GetTournament(type);

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

            return RedirectToAction("ViewTournament", new { id = tournament.TournamentID });
        }




    }
}