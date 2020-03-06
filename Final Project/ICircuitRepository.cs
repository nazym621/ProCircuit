using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace ProCircuit
{
    public interface ICircuitRepository
    {
        public IEnumerable<Aggregate_Credit> GetAllCredit();
        public Aggregate_Credit GetCredit(int id);
        public void UpdateCredit(Aggregate_Credit Aggregate_Credit);
        public void InsertCredit(Aggregate_Credit creditToInsert);
        public IEnumerable<Category> GetCategories();
        public Aggregate_Credit AssignCategory();

    }
}
