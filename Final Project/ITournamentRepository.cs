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
        public Tournament GetTournament(string type);
    }
}
