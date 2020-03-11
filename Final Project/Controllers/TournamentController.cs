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

        public IActionResult ViewTournament(int id)
        {
            var tourney = repo.GetTournament(id);

            return View(tourney);
        }

        public IActionResult UpdateTournament(int id)
        {
            Tournament tourney = repo.GetTournament(id);

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

            return RedirectToAction("ViewCircuitTournaments", new { id = tournament.ID });
        }

        public IActionResult InsertTournament()
        {
            var tourney = repo.AssignCircuitTournaments();

            return View(tourney);
        }

        public IActionResult InsertTournamentToDatabase(Tournament tournamentToInsert)
        {
            repo.InsertTournament(tournamentToInsert);

            return RedirectToAction("Index");
        }










        }
}