using System;
using System.Collections.Generic;

namespace ProCircuit.Models
{
    public class Tournament
    {
        public int Tournament_ID { get; set; }
        public string Name { get; set; }
        public int Total_Prize { get; set; }
        public IEnumerable<Aggregate_Credit> AggregateCredit { get; set; }


    }
}

