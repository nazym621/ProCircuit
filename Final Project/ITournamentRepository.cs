using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace ProCircuit
{
    public interface ITournamentRepository
    {
        public IEnumerable<Tournament> GetAllTournaments();
        public Tournament GetTournament(string name);
        public void UpdateTournament(Tournament tournament);
        public void InsertTournament(Tournament tournamentToInsert);
        public IEnumerable<Aggregate_Credit> GetAllCredit();
        public Tournament AssignAggregateCredit();


    }
}
