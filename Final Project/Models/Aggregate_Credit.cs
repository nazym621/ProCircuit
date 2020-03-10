using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProCircuit.Models;

namespace ProCircuit.Models
{
    public class Aggregate_Credit
    {
        public int Credit_ID { get; set; }
        public int Event_ID { get; set; }
        public int Result_ID { get; set; }
        public int Tournament_ID { get; set; }
        public int Winnings { get; set; }
        public IEnumerable<Tournament> Tournament { get; set; }
        public IEnumerable<Expenses> Expenses { get; set; }

    }
}
