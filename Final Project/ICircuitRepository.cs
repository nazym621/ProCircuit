using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCircuit
{
    public interface ICircuitRepository
    {
        public IEnumerable<CircuitTournaments> GetAllTournaments();
        public CircuitTournaments GetTournaments(int id);
        public void UpdateTournaments(CircuitTournaments circuittournaments);
       
      
    }
}
