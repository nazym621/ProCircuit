using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCircuit
{
    public interface ITournamentRepository
    {
        public IEnumerable<Tournament> GetAllTournaments();
        public Tournament GetTournament(int id);
        public void UpdateTournament(Tournament tournament);
        public void InsertTournament(Tournament tournamentToInsert);
        public IEnumerable<CircuitTournaments> GetTournaments();
        public Tournament AssignCircuitTournaments();



    }
}
