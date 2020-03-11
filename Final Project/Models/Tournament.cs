using System;
using System.Collections.Generic;

namespace ProCircuit.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Total_Prize { get; set; }
        public IEnumerable<CircuitTournaments> CircuitTournaments { get; set; }
        public IEnumerable<Expenses> Expenses { get; set; }
       
    }
}

