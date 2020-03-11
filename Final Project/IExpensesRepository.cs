using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCircuit
{
    public interface IExpensesRepository
    {
        public IEnumerable<Expenses> GetAllExpenses();
        public Expenses GetExpenses(int totalexpenses);
        public void UpdateExpenses(Expenses expenses);
        public void InsertExpenses(Expenses expensesToInsert);
        public IEnumerable<CircuitTournaments> GetTournaments();
        public Expenses AssignCircuitTournaments();
        
    }
}
