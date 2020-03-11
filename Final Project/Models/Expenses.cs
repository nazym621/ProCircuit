using System;
using System.Collections.Generic;

namespace ProCircuit.Models
{
    public class Expenses
    {
        public int ExpensesID { get; set; }
        public int Flight { get; set; }
        public int Transportation { get; set; }
        public int Food { get; set; }
        public int Hotel { get; set; }
        public int TotalExpenses { get; set; }
        public IEnumerable<CircuitTournaments> AggregateCredit { get; set; }
        public IEnumerable<Tournament> Tournament { get; set; }
    }
}
